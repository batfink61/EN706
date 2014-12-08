// Calendar business object (Factory which serves weight recording and exercise events as ICalEvents)
// The Calendar uses the EN706 web service to access data objects (End point defined in web.config)
//
// A calendar serves a list of ICalEvents (an interface that supports different event types)
// Events can be: weighingSession or exerciseSession events
// all events inherit from teh base class Event
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Xml;
using System.Configuration;

namespace SDW_Wellbeing
{
    public class EventCalendar
    {
        private String _userId;
        List<ICalEvent> _events = new List<ICalEvent>();

        // Constructor populates a list of events for the current user.
        // Data is pulled from the data objects, running under the EN706 web service
        // SOAP calls are made to return data formatted in XML
        public EventCalendar(String UserID)
        {
            _userId = UserID;
            List<ICalEvent> events = new List<ICalEvent>();
            en706.Service svc = new en706.Service();

            // Populate events with exercise data for the current user
            XmlNode xdoc=svc.ReadExercise(_userId, ConfigurationManager.AppSettings["startdate"].ToString(), ConfigurationManager.AppSettings["enddate"].ToString());
            foreach (XmlNode nd in xdoc.SelectNodes("exercise"))
            {
                ExerciseSession session = new ExerciseSession(nd);
                _events.Add(session);
            }

            // Populate events with weighing data for the current user
            xdoc = svc.ReadWeight(_userId, ConfigurationManager.AppSettings["startdate"].ToString(), ConfigurationManager.AppSettings["enddate"].ToString());
            foreach (XmlNode nd in xdoc.SelectNodes("weight"))
            {
                WeighingSession session = new WeighingSession(nd);
                _events.Add(session);
            }
        }

        // Return a list of events (exercise/weights) for a specified date.
        public List<ICalEvent> GetDay(DateTime day)
        {
            List<ICalEvent> events = new List<ICalEvent>();
            String strDate = day.ToString("yyyy-MM-dd");
            foreach (ICalEvent evnt in _events)
            {
                if (evnt.EventDate == strDate)
                {
                    events.Add(evnt);
                }

            }
            return events;
        }
    }

    // WeighingSession inherits from the base class Event, which defines common methods/properties, 
    // and implements iCalEvent so that this common interface makes client handling simpler.
    // It also allows us to extend events to other types (e.g. GP visit or progress review)
    public class WeighingSession : Event, ICalEvent
    {
        private int _weight;

        public WeighingSession(XmlNode CalXml)
        {
            _weight = Int32.Parse(CalXml.SelectSingleNode("weight").InnerText);
            EventDate = CalXml.SelectSingleNode("weightdate").InnerText;
        }        

        public CalendarEventType EventType()
        {
            return CalendarEventType.WeighingSession;
        }
        public String Summary()
        {
            return String.Format("Weighed {0} Kg", _weight);
        }
    }

    // ExerciseSession inherits from the base class Event, which defines common methods/properties, 
    // and implements iCalEvent so that this common interface makes client handling simpler.
    // It also allows us to extend events to other types (e.g. GP visit or progress review)
    public class ExerciseSession : Event, ICalEvent
    {
        private int _duration;

        public ExerciseSession(XmlNode CalXml)
        {
            _duration = Int32.Parse(CalXml.SelectSingleNode("duration").InnerText);
            EventDate = CalXml.SelectSingleNode("exercisedate").InnerText;
        }

        public CalendarEventType EventType()
        {
            return CalendarEventType.ExerciseSession;
        }
        public String Summary()
        {
            return String.Format("Exercised for {0} mins", _duration);
        }

    }

    // Interface definition for events on the calendar.
    // All event types must implement this interface so we have a common interface regardless to event/activity on the calendar
    public interface ICalEvent
    {
        String EventDate { get; set; }
        CalendarEventType EventType();
        String Summary();
    }

    public enum CalendarEventType
    {
        WeighingSession,
        ExerciseSession
    }

    // Event base class.
    // More methods/properties are likely in subsequent iterations of 
    // development as the application develops 
    public class Event
    {
        private String _eventDate;

        public String EventDate
        {
            get {
                return _eventDate;
            }
            set {
                _eventDate = value;
            }
        }
    }
}