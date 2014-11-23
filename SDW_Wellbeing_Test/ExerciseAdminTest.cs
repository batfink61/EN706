using SDW_Wellbeing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace SDW_Wellbeing_Test
{
    
    
    /// <summary>
    ///This is a test class for ExerciseAdminTest and is intended
    ///to contain all ExerciseAdminTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ExerciseAdminTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Page_Load
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("U:\\My Documents\\System Development Workshop\\Group Project\\Code\\EN706\\EN706\\SDW_Wellbeing", "/")]
        [UrlToTest("http://localhost:55791/")]
        [DeploymentItem("SDW_Wellbeing.dll")]
        public void Page_LoadTest()
        {
            ExerciseAdmin_Accessor target = new ExerciseAdmin_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.Page_Load(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CreateExercise_Click
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("U:\\My Documents\\System Development Workshop\\Group Project\\Code\\EN706\\EN706\\SDW_Wellbeing", "/")]
        [UrlToTest("http://localhost:55791/")]
        [DeploymentItem("SDW_Wellbeing.dll")]
        public void CreateExercise_ClickTest()
        {
            ExerciseAdmin_Accessor target = new ExerciseAdmin_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            EventArgs e = null; // TODO: Initialize to an appropriate value
            target.CreateExercise_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
