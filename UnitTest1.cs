using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerFinal;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// Test 1.1 : Given sad mood should return sad.
        /// </summary>
        [TestMethod]
        [TestCategory("TC1.1")]
        public void Given_SAD_Mood_Should_Return_SAD()
        {
            //Arrange
            MoodAnalyser call = new MoodAnalyser("I am in sad mood");
            string expected = "SAD";
            //Act
            string mood = call.AnalyseMessage();
            //Assert
            Assert.AreEqual(expected, mood);
        }
        /// <summary>
        /// Given any mood should return happy.
        /// </summary>
        [TestMethod]
        [TestCategory("TC1.2")]
        public void Given_ANY_Mood_Should_Return_HAPPY()
        {
            //Arrange
            MoodAnalyser call = new MoodAnalyser("I am in any mood");
            string expected = "HAPPY";
            //Act
            string mood = call.AnalyseMessage();
            //Assert
            Assert.AreEqual(expected, mood);
        }
        /// <summary>
        /// Given the null input should return happy.
        /// </summary>
        /// <param name="message">The message.</param>
        [TestMethod]
        [TestCategory("Test2.1")]
        [DataRow(null)]
        public void Given_NULL_Input_Should_Return_HAPPY(string message)
        {
            //Arrange
            MoodAnalyser call = new MoodAnalyser(message);
            string expected = "HAPPY";
            //Act
            string mood = call.AnalyseMessage();
            //Assert
            Assert.AreEqual(expected, mood);
        }
        /// <summary>
        /// Given the NULL mood should throw mood analysis custom exception indicating null exception
        /// </summary>
        [TestMethod]
        [TestCategory("Test 3.1")]
        public void Given_NULL_Mood_Should_Throw_MoodAnalysisCustomException()
        {
            try
            {
                string message = null;
                MoodAnalyser call = new MoodAnalyser(message);
                string mood = call.AnalyseMessage();
            }
            catch(MoodAnalyzerCustomException ex)
            {
                Assert.AreEqual("Mood should not be null", ex.Message);
            }
        }
        /// <summary>
        /// Given the empty mood should throw mood analysis custom exception indicating empty mood exception
        /// </summary>
        [TestMethod]
        [TestCategory("Test 3.2")]
        public void Given_EMPTY_Mood_Should_Throw_MooadAnalysisCustomException()
        {
            try
            {
                string message = "";
                MoodAnalyser call = new MoodAnalyser(message);
                string mood = call.AnalyseMessage();
            }
            catch(MoodAnalyzerCustomException ex)
            {
                Assert.AreEqual("Mood should not be empty", ex.Message);
            }
        }
        /// <summary>
        /// Given the mood analyse class name should return mood analyser object.
        /// </summary>
        [TestMethod]
        [TestCategory("Test4.1")]
        public void Given_Mood_Analyse_Class_Name_Should_Return_Mood_Analyser_Object()
        {
            string message = null;
            object expected = new MoodAnalyser(message);
            object obj = MoodAnalyzerFactory.CreateMoodAnalyse("MoodAnalyzerFinal.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
        }
        /// <summary>
        /// Given improper class name should throw exception.
        /// </summary>
        [TestMethod]
        [TestCategory("Test4.2")]
        public void Given_Mood_Analyse_Improper_Class_Name_Should_Throw_Exception()
        {
            string message = null;
            object expected = new MoodAnalyser(message);
            try
            {
                object obj = MoodAnalyzerFactory.CreateMoodAnalyse("MoodAnalyzerF.MoodAnalyse", "MoodAnalyser");
            }
            catch(MoodAnalyzerCustomException ex)
            {
                Assert.AreEqual("Class not found", ex.Message);
            }
        }
        /// <summary>
        /// Given improper constructor name should throw exception.
        /// </summary>
        [TestMethod]
        [TestCategory("Test4.3")]
        public void Given_Mood_Analyse_Improper_Constructor_Name_Should_Throw_Exception()
        {
            string message = null;
            object expected = new MoodAnalyser(message);
            try
            {
                object obj = MoodAnalyzerFactory.CreateMoodAnalyse("MoodAnalyzerFinal.MoodAnalyser", "Mood");
            }
            catch (MoodAnalyzerCustomException ex)
            {
                Assert.AreEqual("Constructor not found", ex.Message);
            }
        }
        /// <summary>
        /// Given the correct class name should return mood analyzer object using parameterized constructor.
        /// </summary>
        [TestMethod]
        [TestCategory("Test5.1")]
        public void Given_Correct_Class_Name_Should_Return_Mood_Analyzer_Object_Using_Parameterized_Constructor()
        {
            object expected = new MoodAnalyser("HAPPY");
            object obj = MoodAnalyzerFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyzerFinal.MoodAnalyser", "MoodAnalyser", "HAPPY");
            expected.Equals(obj);
        }
        /// <summary>
        /// Given the improper class name should throw exception using parameterized construcrtor.
        /// </summary>
        [TestMethod]
        [TestCategory("Test5.2")]
        public void Given_Mood_Analyse_Improper_Class_Name_Should_Throw_Exception_Using_Parameterized_Construcrtor()
        {
            string message = "HAPPY";
            object expected = new MoodAnalyser(message);
            try
            {
                object obj = MoodAnalyzerFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyzerF.MoodAnalyse", "MoodAnalyser",message);
            }
            catch (MoodAnalyzerCustomException ex)
            {
                Assert.AreEqual("Class not found", ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("Test5.3")]
        public void Given_Mood_Analyse_Improper_Constructor_Name_Should_Throw_Exception_Using_Parameterized_Constructor()
        {
            string message = "HAPPY";
            object expected = new MoodAnalyser(message);
            try
            {
                object obj = MoodAnalyzerFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyzerFinal.MoodAnalyser", "Mood",message);
            }
            catch (MoodAnalyzerCustomException ex)
            {
                Assert.AreEqual("Constructor not found", ex.Message);
            }
        }
        /// <summary>
        /// Giving the happy message through invoking method using reflection.
        /// </summary>
        [TestMethod]
        [TestCategory("Test6.1")]
        public void Giving_Happy_Message_Through_Invoking_Method_Using_Reflection()
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser("me feeling happy");
            object actual = MoodAnalyzerFactory.InvokeAnalyseMoodMethod("MoodAnalyzerFinal.MoodAnalyser", "MoodAnalyser", "me feeling happy", "AnalyseMessage");
            Assert.AreEqual("HAPPY", actual);
        }
        [TestMethod]
        [TestCategory("Test6.2")]
        public void Invoking_Using_Wrong_Method_Name_Should_Throw_Exception()
        {
            try
            {
                MoodAnalyser moodAnalyser = new MoodAnalyser("me feeling happy");
                object obj = MoodAnalyzerFactory.InvokeAnalyseMoodMethod("MoodAnalyzerFinal.MoodAnalyser", "MoodAnalyser", "me feeling happy", "Amalyse");
            }
            catch(MoodAnalyzerCustomException ex)
            {
                Assert.AreEqual("Method not found", ex.Message);
            }
        }
    }
}
