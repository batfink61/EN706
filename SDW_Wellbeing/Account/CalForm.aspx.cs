// This is the users home page.
// Displaying a calendar of events along with links to supporting pages
// with information on weight control and exercise
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace SDW_Wellbeing
{
    public partial class _CalForm : System.Web.UI.Page
    {
        private EventCalendar _userCalendar; // holds the calendar for the current user

        protected void Page_Load(object sender, EventArgs e)
        {
            // We need to load the event calendar for the current user so that we can display activity by day

            _userCalendar = new EventCalendar(Request.Cookies["profile"]["name"]);
            RefreshSummary();
        }

        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            // User has changed the day they are viewing so refresh a summary of events (weight/exercise recordings)

            RefreshSummary();
        }

        private void RefreshSummary()
        {
            // Display a summary of events for the currently selected date

            StringBuilder sb = new StringBuilder();
            foreach (ICalEvent evnt in _userCalendar.GetDay(Calendar.SelectedDate))
            {
                sb.Append(evnt.Summary());
                sb.Append("<br />");
            }
            CalSummary.Text = sb.ToString();
        }

        protected void Calendar_DayRender(object sender, DayRenderEventArgs e)
        {
            // Check to see if the rendered day has any activity. If so then change background of calendar cell
            // so that user has visual cue that activity exists

            if (_userCalendar.GetDay(e.Day.Date).Count > 0)
            {
                e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#e2e8ee");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string f = "1";
        }
    }
}
