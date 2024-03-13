using NetflixRareBackend.Models;

namespace NetflixRareBackend.Data
{
    public class UserData
    {
        public static List<User> Users = new List<User>()
        {
            new User {Id = 1, First_Name = "Django", Last_Name = "Reinhardt", Bio = "I'm a weird little freak", Profile_Image_Url = "https://tse3.mm.bing.net/th?id=OIP.RFj9Podx_VZPomRF-Eu_xQHaHa&pid=Api&P=0&h=220", Email = "dj1946@yahoo.com", Created_On = new DateTime(2023, 6, 14), Active = true, Is_Staff = true, Uid = "ZP734FG"},
            new User {Id = 2, First_Name = "Rita", Last_Name = "Hayworth", Bio = "I'm a hot tomato", Profile_Image_Url = "https://tse3.mm.bing.net/th?id=OIP.gODAc8rZRPjtRWthtwjA-AHaKK&pid=Api&P=0&h=220", Email = "ritaskeeta@hotmail.com", Created_On = new DateTime(2023, 8, 27), Active = true, Is_Staff = true, Uid = "PG5H372"},
            new User {Id = 3, First_Name = "Gladys", Last_Name = "Knight", Bio = "I'm a songstress", Profile_Image_Url = "https://tse3.mm.bing.net/th?id=OIP.IKtEhuzNEmbk6cdHtqpYYAHaLc&pid=Api&P=0&h=220", Email = "midnighttrain@gmail.com", Created_On = new DateTime(2024, 2, 1), Active = true, Is_Staff = true, Uid = "A83D98K"}


        };
    }
}
