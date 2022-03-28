using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static MoodAnalyserUC7.CustomException;

namespace MoodAnalyserUC7
{
    public class MoodAnalyserReflector
    {
        //CreateMoodAnalyser method to creat object of MoodAnalyser class with Default Constructor.
        public static object CreateMoodAnalyser(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new CustomException(CustomException.ExceptionType.NO_SUCH_CLASS, "Class Not Found");
                }
            }
            else
            {
                throw new CustomException(CustomException.ExceptionType.NO_SUCH_METHOD, "Constructor is Not Found");
            }
        }

        //CreateMoodAnalyserUsingParameterizedConstructor method to creat object of MoodAnalyser class with Parameterised Constructor.
        public static object CreateMoodAnalyserUsingParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                    object instance = constructorInfo.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new CustomException(CustomException.ExceptionType.NO_SUCH_METHOD, "Constructor is Not Found");
                }
            }
            else
            {
                throw new CustomException(CustomException.ExceptionType.NO_SUCH_CLASS, "Class is Not Found");
            }
        }

        // Use Reflector to invoke MoodAnalyzer method 
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("Mood_Analyser_Problems.MoodAnalyser");
                object moodAnalyseObject = MoodAnalyserReflector.CreateMoodAnalyserUsingParameterizedConstructor("Mood_Analyser_Problems.MoodAnalyser", "MoodAnalyser", message);
                MethodInfo methodeInfo = type.GetMethod(methodName);
                object mood = methodeInfo.Invoke(moodAnalyseObject, null);
                return mood.ToString();
            }
            catch
            {
                throw new CustomException(CustomException.ExceptionType.NO_SUCH_METHOD, "Method is not found");
            }
        }

        // Use SetField Method to change mood dynamically.
        public static string SetField(string value, string fieldName)
        {
            try
            {
                MoodAnalyser obj = (MoodAnalyser)CreateMoodAnalyserUsingParameterizedConstructor("Mood_Analyser_Problem.MoodAnalyser", "MoodAnalyser", value);
                Type type = typeof(MoodAnalyser);
                FieldInfo fieldInfo = type.GetField(fieldName);
                if (fieldInfo != null)
                {
                    if (value == null)
                    {
                        throw new CustomException(ExceptionType.EMPTY_MESSAGE, "Message should not be null");
                    }
                    fieldInfo.SetValue(obj, value);
                    return obj.message;
                }
                throw new CustomException(ExceptionType.NO_SUCH_FIELD, "Field not found");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
