namespace MainProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task1

            var Square = FigureArea.FigureArea.Square(3.54);

            var Rectangle = FigureArea.FigureArea.Rectangle(3.54, 3.44);

            var Triangle = FigureArea.FigureArea.Triangle(4.5, 3);

            #endregion

            #region Task2

            var a = CheckString.Check.IsPolidrom("mom");

            var b = CheckString.Check.NumOfOffers("Hello. My little Word!");

            var c = CheckString.Check.GetReverse("HELLO");

            #endregion

            #region Task3

            var cp1 = CheckPerson.Person.IsLetters("123Анатолий");
            var cp2 = CheckPerson.Person.IsLetters("Анатолий");

            var cp3 = CheckPerson.Person.IsDigit("123");
            var cp4 = CheckPerson.Person.IsDigit("123123a");

            var cp5 = CheckPerson.Person.IsPhoneNum("456-456-4455");
            var cp6 = CheckPerson.Person.IsPhoneNum("456-456-456");


            // хз, тупорылое задание, можно проверить через регулярку, но это не понацея, так как может пропустить, а может и нет.
            // Вычитал что отличный способ проверить email, это отправить письмо с уникальной ссылкой, но как оно на практике, хз
            var cp7 = CheckPerson.Person.IsPhoneNum("ggame@gmail.com");
            var cp8 = CheckPerson.Person.IsPhoneNum("asdjk12l3@gmail");


            #endregion

            #region Task4 and 5

            MyFileClass.FileClass.CopyFile(@"c:\emp.json", @"c:\c++\emp.json");

            MyFileClass.FileClass.CopyDirectory(@"c:\VisualStudio", @"c:\Learning");

            MyFileClass.FileClass.DeleteFile(@"c:\emp.json");

            MyFileClass.FileClass.DeleteFileOnMask(@"c:\test", ".json");

            MyFileClass.FileClass.MoveFile(@"c:\123.txt", @"c:\test\1234.txt");


            // TASK 5
            MyFileClass.FileClass.SearchWord(@"c:\test\123.txt", "привет", @"c:\test");

            MyFileClass.FileClass.SearchWordOnFolder(@"c:\test", "привет");


            #endregion
        }
    }
}