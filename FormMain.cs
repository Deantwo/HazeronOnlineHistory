#define TEN_INTERVAL
#define SNAP

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Globalization;

namespace HazeronOnlineHistory
{
    public partial class FormMain : Form
    {
        const string URL_PLAYERHISTORY = @"https://hazeron.com/playerhistory.txt";
        Dictionary<DateTime, int> _playerHistory;
        CultureInfo _providerCI = CultureInfo.InvariantCulture;
        DateTime _httpLastUpdate = new DateTime(2015, 10, 28);

        public FormMain()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            comboBox1.SelectedIndex = 0;

            dateTimePicker1.Value = dateTimePicker1.Value.AddDays(-7);
            dateTimePicker2.MaxDate = dateTimePicker2.Value.AddDays(1);
            chart1_Resize(chart1, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Start label.
                tbxRecord.Text = $"Getting data from {URL_PLAYERHISTORY}";
                int dataCount = 0;

                // Define a record variable.
                KeyValuePair<DateTime, int> record = new KeyValuePair<DateTime, int>(_httpLastUpdate, 0);

                // Create the HTTP GET request.
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URL_PLAYERHISTORY);
                request.IfModifiedSince = _httpLastUpdate;
                //request.Timeout = 5000;
                request.Method = "GET";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    // Save the date of the last page update.
                    _httpLastUpdate = response.LastModified;

                    // Clear the current list.
                    _playerHistory = new Dictionary<DateTime, int>();

                    // Read the page stream.
                    using (Stream receiveStream = response.GetResponseStream())
                    {
                        StreamReader sr = new StreamReader(receiveStream, Encoding.UTF8);
                        string httpLine;
                        while ((httpLine = sr.ReadLine()) != null)
                        {
                            int komma = httpLine.IndexOf(',');
                            //                         Wed Oct 28 00:52:02 2015 GMT
                            //                         Mon Nov 2 11:00:02 2015 GMT
                            const string dateFormat = "ddd MMM d HH:mm:ss yyyy 'GMT'";
                            string dateString = httpLine.Substring(1, komma - 2);
                            DateTime date = DateTime.ParseExact(dateString, dateFormat, _providerCI);
#if TEN_INTERVAL
                            // Only want the 10 minute interval entries.
                            if (date.Minute % 10 != 0)
                                continue;
#endif
#if SNAP
                            // Minor correction to make all DateTime seconds be ':01.0'.
                            date = date.AddSeconds(1 - date.Second).AddMilliseconds(-date.Millisecond);
#endif
                            string amountString = httpLine.Substring(komma + 3, httpLine.Length - komma - 4);
                            int amount = Convert.ToInt32(amountString);

                            // Check record.
                            if (record.Value < amount)
                                record = new KeyValuePair<DateTime, int>(date, amount);

                            // Add the datetime and amount to the dictionary.
                            //System.Diagnostics.Debug.WriteLine(date.ToString() + "\t" + amount.ToString());
                            if (_playerHistory.ContainsKey(date))
                                System.Diagnostics.Debug.WriteLine($"*** Duplicate Entry: {date}\t{amount}\t{_playerHistory[date]}");
                            else
                                _playerHistory.Add(date, amount);

                            // Increment data counter and update label.
                            dataCount++;
                            tbxRecord.Text = $"{dataCount} data points collected.";
                            tbxRecord.Refresh();
                        }
                    }
                }

                // Write the record in the textbox.
                tbxRecord.Text = $"Current highest recorded number of online avatars at one time was {record.Value} at {record.Key}";
            }
            catch (WebException ex)
            {
                // Is it a IfModifiedSince error?
                HttpWebResponse response = (HttpWebResponse)ex.Response;
                if (response != null && response.StatusCode == HttpStatusCode.NotModified)
                {
                    // The last HTTP GET attempt is still the latest, do nothing.
                    System.Diagnostics.Debug.WriteLine($"*** HTTP GET IfModifiedSince Error: {_httpLastUpdate}\t{response.LastModified}");
                    _httpLastUpdate = response.LastModified;
                }
                else
                    throw;
            }

            // Update the chart.
            UpdateChart();

            // Change button text to show that we already have data.
            button1.Text = "Update";
            menuStrip1FileButton1.Text = "Update";
        }

        private void UpdateChart()
        {
            chart1_Resize(chart1, null);
            if (_playerHistory != null && _playerHistory.Count != 0)
            {
                chart1.Series[0].Points.Clear();
                foreach (KeyValuePair<DateTime, int> entry in Groupby(_playerHistory))
                {
                    if (DateTime.Compare(entry.Key, dateTimePicker1.Value.Date) > -1
                     && DateTime.Compare(entry.Key, dateTimePicker2.Value.Date.AddDays(1)) < 1)
                        chart1.Series[0].Points.AddXY(entry.Key, entry.Value);
                }
                if (DateTime.Compare(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date) == 0)
                    chart1.ChartAreas[0].Axes[0].LabelStyle.Format = "f"; //"yyyy-MM-dd HH:mm";
                else
                    chart1.ChartAreas[0].Axes[0].LabelStyle.Format = "D"; //"yyyy-MM-dd";
            }
            chart1.Invalidate();
        }

        private Dictionary<DateTime, int> Groupby(Dictionary<DateTime, int> data)
        {
            return data.GroupBy(x => DatetimeInterval(x.Key))
                       .ToDictionary(k => k.Key,
                                     v => v.Max(x => x.Value));
        }

        private DateTime DatetimeInterval(DateTime datetime)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    return datetime.Date.AddHours(datetime.Hour).AddMinutes(datetime.Minute);
                case 1:
                    return datetime.Date.AddHours(datetime.Hour);
                case 2:
                    return datetime.Date.AddHours(FloorSignificat(datetime.Hour, 2));
                case 3:
                    return datetime.Date.AddHours(FloorSignificat(datetime.Hour, 6));
                case 4:
                    return datetime.Date.AddHours(FloorSignificat(datetime.Hour, 12));
                case 5:
                    return datetime.Date;
                case 6:
                    return new DateTime(datetime.Year, datetime.Month, FloorSignificat(datetime.Day, 2, 1, DateTime.DaysInMonth(datetime.Year, datetime.Month)));
                case 7:
                    return new DateTime(datetime.Year, datetime.Month, FloorSignificat(datetime.Day, 7, 1, DateTime.DaysInMonth(datetime.Year, datetime.Month)));
                case 8:
                    return new DateTime(datetime.Year, datetime.Month, 1);
                case 9:
                    return new DateTime(datetime.Year, FloorSignificat(datetime.Month, 2, 1, 12), 1);
                case 10:
                    return new DateTime(datetime.Year, FloorSignificat(datetime.Month, 4, 1, 12), 1);
                case 11:
                    return new DateTime(datetime.Year, 1, 1);
                default:
                    throw new Exception();
            }
        }

        private int FloorSignificat(int number, int significat, int min, int max)
        {
            return Math.Max(Math.Min(FloorSignificat(number, significat), max), min);
        }
        private int FloorSignificat(int number, int significat)
        {
            return (int)(Math.Round((double)number / significat) * significat);
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = dateTimePicker2.Value;
            dateTimePicker2.MinDate = dateTimePicker1.Value;

            UpdateChart();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateChart();
        }

        int CHART_TOP;
        int CHART_LEFT;
        int CHART_BUTTOM;
        int CHART_RIGHT;
        const int CHART_LABEL = 10;

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if (chart1.Series[0].Points.Count == 0
             || e.Y + ((Control)sender).Top <= CHART_TOP
             || e.X + ((Control)sender).Left <= CHART_LEFT
             || e.Y + ((Control)sender).Top >= CHART_BUTTOM
             || e.X + ((Control)sender).Left >= CHART_RIGHT)
            {
                axisY.Visible = false;
                axisX.Visible = false;
                axisLabel.Visible = false;
            }
            else
#if SNAP
            {
                axisY.Visible = true;
                axisX.Visible = true;
                axisLabel.Visible = true;

                DateTime valueXDate = DateTime.FromOADate(chart1.ChartAreas[0].AxisX2.PixelPositionToValue(e.X));
                // Minor correction to make all DateTime seconds be ':01.0'.
                valueXDate = valueXDate.AddSeconds(1 - valueXDate.Second).AddMilliseconds(-valueXDate.Millisecond);
                // Round to nearest 10 minute.
                valueXDate = DatetimeInterval(valueXDate);
                double valueX = valueXDate.ToOADate();

                double valueY = 0;
                if (valueX < chart1.Series[0].Points.First().XValue)
                {
                    valueY = chart1.Series[0].Points.First().YValues[0];
                    valueX = chart1.Series[0].Points.First().XValue;
                }
                else if (valueX > chart1.Series[0].Points.Last().XValue)
                {
                    valueY = chart1.Series[0].Points.Last().YValues[0];
                    valueX = chart1.Series[0].Points.Last().XValue;
                }
                else
                {
                    var data = chart1.Series[0].Points.FirstOrDefault(x => x.XValue == valueX);
                    if (data != null)
                        valueY = data.YValues[0];
                }

                axisX.Location = new Point((int)chart1.ChartAreas[0].AxisX2.ValueToPixelPosition(valueX) + ((Control)sender).Left, CHART_TOP);
                axisY.Location = new Point(CHART_LEFT, (int)chart1.ChartAreas[0].AxisY2.ValueToPixelPosition(valueY) + ((Control)sender).Top);

                axisLabel.Text = DateTime.FromOADate(valueX).ToString("yyyy-MM-dd HH:mm") + Environment.NewLine + Math.Round(valueY).ToString() + " avatars";
                axisLabel.Location = new Point(e.X + ((Control)sender).Left + CHART_LABEL, e.Y + ((Control)sender).Top + CHART_LABEL);
            }
#else
            {
                axisY.Visible = true;
                axisX.Visible = true;
                axisLabel.Visible = true;

                axisX.Location = new Point(e.X + ((Control)sender).Left, CHART_TOP);
                axisY.Location = new Point(CHART_LEFT, e.Y + ((Control)sender).Top);

                DateTime valueX = DateTime.FromOADate(chart1.ChartAreas[0].AxisX2.PixelPositionToValue(e.X));
                double valueY = chart1.ChartAreas[0].AxisY2.PixelPositionToValue(e.Y);
                axisLabel.Text = valueX.ToString("yyyy-MM-dd HH:mm") + Environment.NewLine + Math.Round(valueY).ToString() + " avatars";
                axisLabel.Location = new Point(e.X + ((Control)sender).Left + CHART_LABEL, e.Y + ((Control)sender).Top + CHART_LABEL);
            }
#endif
        }

        private void chart1_Resize(object sender, EventArgs e)
        {
            CHART_TOP = ((Control)sender).Top + 10;
            CHART_LEFT = ((Control)sender).Left + 10;
            CHART_BUTTOM = ((Control)sender).Top + ((Control)sender).Size.Height - 10;
            CHART_RIGHT = ((Control)sender).Left + ((Control)sender).Size.Width - 10;

            axisY.Size = new Size(CHART_RIGHT - CHART_LEFT, 1);
            axisX.Size = new Size(1, CHART_BUTTOM - CHART_TOP);
        }

        #region menuStrip1
        private void menuStrip1FileButton1_Click(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void menuStrip1FileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void menuStrip1HelpGithub_Click(object sender, EventArgs e)
        //{
        //    System.Diagnostics.Process.Start(@"https://github.com/Deantwo/HazeronAdviser");
        //}

        //private void menuStrip1HelpThread_Click(object sender, EventArgs e)
        //{
        //    System.Diagnostics.Process.Start(@"http://hazeron.com/phpBB3/viewtopic.php?f=124&t=6867#p77419");
        //}

        private void menuStrip1HelpAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Program:" + Environment.NewLine +
                "   Hazeron Online History Graph" + Environment.NewLine +
                "" + Environment.NewLine +
                "Version:" + Environment.NewLine +
                "   v" + Application.ProductVersion + Environment.NewLine +
                "" + Environment.NewLine +
                "Creator:" + Environment.NewLine +
                "   Deantwo" + Environment.NewLine +
                "" + Environment.NewLine +
                "Feedback, suggestions, and bug reports should be PMed to Deantwo please."
                , "About Hazeron Online History Graph", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
        #endregion
    }
}
