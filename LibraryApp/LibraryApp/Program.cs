namespace LibraryApp;

class Program
{
    static void Main(string[] args)
    {
        BookSystems bookSystems = new BookSystems();

        try
        {
            Console.WriteLine("Hoşgeldiniz:");
            Console.WriteLine("Hesabınız var mı? ( e - h )");
            char ch = char.Parse(Console.ReadLine());

            

            if (ch=='e')
            {
                Console.WriteLine("Giriş Yap\n" +
                    "******************");

                bool IsLoginSuccess = false;
                while (!IsLoginSuccess)
                {
                    Console.WriteLine("Kullanici adini giriniz:");
                    string userName = Console.ReadLine();
                    Console.WriteLine("Sifrenizi giriniz:");
                    string password = Console.ReadLine();
                    bookSystems.LogIn(userName, password);



                    if (!IsLoginSuccess)
                    {
                        Console.WriteLine("Yanlış kullanıcı adı ya da şifre. Tekrar deneyin.");
                    }
                }


            }
            else if(ch=='h'){
                Console.WriteLine("Kayıt Ol\n" +
                    "******************");
                Console.WriteLine("Kullanici adini giriniz:");
                string userName = Console.ReadLine();
                Console.WriteLine("Kullanici soyadini giriniz:");
                string userSurname = Console.ReadLine();
                Console.WriteLine("Sifrenizi girin:");
                string password = Console.ReadLine();
                bool isAdmin = false;
                bookSystems.Register(userName,userSurname,password,isAdmin);

                bookSystems.LogIn(userName,password);

            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("Gecerli bir islem gerceklestirin");
        }


        Console.ReadLine();
    }
}
public class User
{
    public string UserName { get; set; }
    public string UserSurname { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; }

    public User(string userName, string userSurname,string password,bool isAdmin )
    {
        UserName = userName;
        UserSurname = userSurname;
        Password = password;
        IsAdmin = isAdmin;
    }

}
public class Book
{
    public string BookName { get; set; }
    public string Author { get; set; }
    public int NumberofPage { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }

    public Book(string bookName, string author, string category, int numberofPage, double price )
    {
        BookName = bookName;
        Author = author;
        NumberofPage = numberofPage;
        Price = price;
        Category = category;

    }
}
public class BookSystems
{
    public List<User> users = new List<User>
    {
        new User ("enver","ucpinar","1234",true),
        new User ("barbaros","ciga","1234",false)
    };

    public List<Book> books = new List<Book>
    {
        new Book ("dsad","defw","dsadsa",54,54),
        new Book ("uçurtma avcısı","dsadsa","dsads",25,56),
    };

    public void LogIn(string userName, string password)
    {
        
        for (int i = 0; i < users.Count; i++)
        {
            
            if (users[i].UserName == userName && users[i].Password == password)
            {

                if (users[i].IsAdmin)
                {
                    Console.WriteLine($"Merhaba Admin {users[i].UserName}");
                    while (true)
                    {
                        // Giriş yapan kullanıcının admin olup olmamasına karşılık iki farklı panel

                        Console.WriteLine("Yapmak istediğiniz işlemi seçin:\n" +
                            "1) Kitapları Görüntüle\n" +
                            "2) Üyeleri görüntüle\n" +
                            "3) Kitap Ekle\n" +
                            "4) Kitap Sil\n" +
                            "5) Kitap Ara\n" +
                            "6) Çıkış");

                        string choose = Console.ReadLine();
                        switch (choose)
                        {
                            case "1":
                                PrintBooks();
                                break;
                            case "2":
                                PrintMembers();
                                break;
                            case "3":
                                Console.WriteLine("Kitap adi:");
                                string bookName = Console.ReadLine();
                                Console.WriteLine("Yazar adi:");
                                string author = Console.ReadLine();
                                Console.WriteLine("Kategori:");
                                string category = Console.ReadLine();
                                Console.WriteLine("Fiyat:");
                                double price = double.Parse(Console.ReadLine());
                                Console.WriteLine("Sayfa sayisi");
                                int numberofPage = int.Parse(Console.ReadLine());
                                AddBook(bookName, author, category, numberofPage, price);
                                break;
                            case "4":
                                Console.WriteLine("Kitap adi:");
                                string removeBookName = Console.ReadLine();
                                RemoveBook(removeBookName);
                                break;
                            case "5":
                                Console.WriteLine("Kitap adi,yazar adi ya da kategori girin:");
                                string searchBook = Console.ReadLine();
                                Search(searchBook);
                                break;
                            case "6":
                                return;
                            default:
                                break;
                        }
                    }

                }
                else
                {
                    Console.WriteLine($"Merhaba {users[i].UserName}");
                    while (true)
                    {
                        // Giriş yapan kullanıcının admin olup olmamasına karşılık iki farklı panel

                        Console.WriteLine("Yapmak istediğiniz işlemi seçin:\n" +
                            "1) Kitapları Görüntüle\n" +
                            "2) Çıkış" 
    );

                        string choose = Console.ReadLine();
                        switch (choose)
                        {
                            case "1":
                                PrintBooks();
                                break;
                            case "2":
                                return;
                            default:
                                break;
                        }
                    }

                }
            }


        }



    }

    public void Register(string userName, string surName, string password,bool isAdmin)
    {
        User user = new User(userName, surName, password,isAdmin);
        users.Add(user);
    }

    public void PrintBooks()
    {
        Console.WriteLine("Kitaplar\n" +
            "********************");
        if (books.Count>0)
        {
            foreach (var item in books)
            {
                Console.WriteLine($"Kitap Adi: {item.BookName}, Yazar Adi: {item.Author}, Kategori: {item.Category} Fiyat: {item.Price} Sayfa sayisi: {item.NumberofPage}");
            }
        }
        else
        {
            Console.WriteLine("Kayitli kitap bulunmamaktadir");
        }

    }

    public void PrintMembers()
    {
        foreach (var item in users)
        {
            Console.WriteLine($"Name: {item.UserName} Password: {item.Password} isAdmin: {item.IsAdmin} ");
        }
    }

    public void AddBook(string bookName, string author,string category, int numberofPage, double price)
    {
        Book book = new Book(bookName, author,category, numberofPage,price);
        books.Add(book);
    }

    public void RemoveBook(string removeBookName)
    {
        foreach (var item in books)
        {
            Console.WriteLine($"Kitap Adi: {item.BookName}, Yazar Adi: {item.Author}, Kategori: {item.Category}, Fiyat: {item.Price} Sayfa sayisi: {item.NumberofPage}");
        }

        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].BookName.Contains(removeBookName))
            {
                books.RemoveAt(i);
            }
        }
    }

    public void Search(string searchBook)
    {
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].BookName.Contains(searchBook) || books[i].Author.Contains(searchBook) || books[i].Category.Contains(searchBook))
            {
                Console.WriteLine($"Kitap Adi: {books[i].BookName}, Yazar Adi: {books[i].Author}, Kategori: {books[i].Category} Fiyat: {books[i].Price} Sayfa sayisi: {books[i].NumberofPage}");
            }
        }
    }




}

