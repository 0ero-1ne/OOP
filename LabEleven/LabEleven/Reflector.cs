using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LabEleven
{
    static class Reflector
    {
        private static StreamWriter _s;

        public static string GetBuildName(string className)
        {
            Type classType = Type.GetType(className, false, true);
            _s = new StreamWriter(@"D:\OOP\OOP\LabEleven\LabEleven\File.txt", true);
            _s.WriteLine($"Full name of assembly of class {classType.Name}: {classType.Assembly.GetName().FullName}\n");
            _s.Close();

            return classType.Assembly.GetName().FullName;
        }

        public static bool HasPublicContructors(string className)
        {
            Type classType = Type.GetType(className, false, true);
            var hasPublic = classType.GetConstructors(BindingFlags.Public);

            _s = new StreamWriter(@"D:\OOP\OOP\LabEleven\LabEleven\File.txt", true);
            _s.WriteLine($"Does class {classType.Name} has public constructors: {hasPublic != null}\n");
            _s.Close();

            return hasPublic != null;
        }

        public static IEnumerable<string> GetPublicMethods(string className)
        {
            Type classType = Type.GetType(className, false, true);
            var methods = classType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            MethodInfo[] publicMethods = classType.GetMethods();
            IEnumerable<string> result = publicMethods.Where(method => method.IsPublic).Select(method => method.Name);

            _s = new StreamWriter(@"D:\OOP\OOP\LabEleven\LabEleven\File.txt", true);
            _s.WriteLine($"Public methods of class {classType.Name}:");
            foreach (var method in result)
            {
                _s.WriteLine(method);
            }
            _s.WriteLine();
            _s.Close();

            return result;
        }

        public static IEnumerable<string> GetFieldsAndProperties(string className)
        {
            Type classType = Type.GetType(className, false, true);
            var fields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);
            var properties = classType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);
            var result = fields.Select(field => field.Name + ": " + field.FieldType)
                         .Concat(properties.Select(property => property.Name + ": " + property.PropertyType));

            _s = new StreamWriter(@"D:\OOP\OOP\LabEleven\LabEleven\File.txt", true);
            _s.WriteLine($"Fields and propertires of class {classType.Name}:");
            foreach (var obj in result)
            {
                _s.WriteLine(obj);
            }
            _s.WriteLine();
            _s.Close();

            return result;
        }

        public static IEnumerable<string> GetInterfaces(string className)
        {
            Type classType = Type.GetType(className, false, true);
            var interfaces = classType.GetInterfaces();
            var result = interfaces.Select(inter => inter.Name + ": " + inter.FullName);

            _s = new StreamWriter(@"D:\OOP\OOP\LabEleven\LabEleven\File.txt", true);
            _s.WriteLine($"Interfaces of class {classType.Name}:");
            foreach (var inter in result)
            {
                _s.WriteLine(inter);
            }
            _s.WriteLine();
            _s.Close();

            return result;
        }

        public static IEnumerable<string> GetAllMethodWithParameter(string className, string userParameter)
        {
            Type classType = Type.GetType(className, false, true);
            var methods = classType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            var result = methods.Where(method => method.GetParameters().Any(param => param.Name.ToLower() == userParameter.ToLower()))
                         .Select(method => method.Name + ": method has parameter " + userParameter.ToLower());

            _s = new StreamWriter(@"D:\OOP\OOP\LabEleven\LabEleven\File.txt", true);
            _s.WriteLine($"Methods of class {classType.Name} with parameter {userParameter.ToLower()}:");
            foreach (var method in result)
            {
                _s.WriteLine(method);
            }
            _s.WriteLine();
            _s.Close();

            return result;
        }

        public static void InvokeMethod(object researchClass, string methodName)
        {
            Type classType = researchClass.GetType();

            var method = classType.GetMethod(methodName);
            var paramsList = File.ReadAllLines(@"D:\OOP\OOP\LabEleven\LabEleven\Invoke.txt").ToList();

            foreach (var param in paramsList)
            {
                object[] p =
                {
                    Convert.ToInt32(param.Substring(0, param.IndexOf(" "))),
                    Convert.ToInt32(param.Substring(param.IndexOf(" ")))
                };

                Console.WriteLine(method.Invoke(researchClass, p));
            }
        }

        public static T Create<T>()
        {
            return Activator.CreateInstance<T>();
        }
    }
}
