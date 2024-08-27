using System;
using Microsoft.EntityFrameworkCore;
using OnlineShop;
using OnlineShop.Models;

class Program {
    static void Main(string[] args) {

        var optionsBuilder = new DbContextOptionsBuilder<PostgresContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=2005");
        bool result = false;
        bool main = true;
        var bas = new List<Basket>();
        while(main) {
            Console.WriteLine("Добро пожаловать в наш велосипедный онлайн-магазин!");
            Console.WriteLine("Выпишите нужную цифру для вашей требуемой операции");

            Console.WriteLine("1 - Список товаров");
            Console.WriteLine("2 - Only for staff");
            Console.WriteLine("3 - Корзина товаров");
            int vvod = Convert.ToInt32(Console.ReadLine());
            bool vvod1 = false;
            while(!vvod1) {
                if(vvod == 1 || vvod == 2 || vvod == 3) {
                    vvod1 = true;
                } else {
                    Console.WriteLine("Мы не смогли распознать вашу команду, попробуйте пожалуйста еще раз");
                    vvod = Convert.ToInt32(Console.ReadLine());
                }
            }
           

            bool choose = false;
            while(!choose)
                switch(vvod) {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Выберите, что вы собираетесь купить: ");
                        Console.WriteLine("1 - Велосипеды");
                        Console.WriteLine("2 - Аксессуары к велосипеду");
                        Console.WriteLine("3 - Вернуться к основному меню");


                        int vtoroivvod = Convert.ToInt32(Console.ReadLine());
                        switch(vtoroivvod) {
                            case 1:
                                Console.Clear();
                                Velosipedy();

                                break;

                            case 2:
                                Console.Clear();
                                veshi();

                                break;
                            case 3:
                                Console.Clear();

                                break;

                        }

                        choose = true;
                        break;
                    case 2:
                        Console.Clear();
                        login();
                        choose = true;
                        if(result) {
                            
                            
                        } else {
                            Console.Clear();
                        }
                        break;
                    case 3:
                        Console.Clear();
                        int sum = 0;
                        if(bas.Any()) {
                            Console.WriteLine("Корзина товаров:");
                            foreach(var b in bas) {
                                Console.WriteLine($"Вещь: {b.Name,-5} | Цена: {b.Price}");
                                sum += b.Price;
                            }
                            Console.WriteLine();
                            Console.WriteLine($"Общая сумма: {sum}");
                            Console.WriteLine("---------------------------------------------------");



                        } else {
                            Console.WriteLine("Корзина пуста!!!");
                            Console.WriteLine("---------------------------------------------------");
                            
                            
                        }
                        
                        Console.WriteLine("Нажмите 1, чтобы вернуться, 2 чтобы покинуть магазин");
                        
                        bool proverka = false;
                        while(!proverka) {
                            int tretivvod = Convert.ToInt32(Console.ReadLine());
                            switch(tretivvod) {
                                case 1:
                                    choose = true;
                                    proverka = true;
                                    Console.Clear();
                                    break;
                                case 2:
                                    choose = true;
                                    main = false;
                                    proverka = true;
                                    break;
                                default:
                                    Console.WriteLine("Ошибка, попробуйте еще раз");
                                    break;
                            }
                        }
                        break;
                       
                }
            
            
        }
        void afterlogin() {
            Console.WriteLine("Такие дела");
        }


        void login() {
            

            Console.WriteLine("Введите пароль для входа в систему: ");
            Console.WriteLine("Или нажмите 1, чтобы выйти из режим администратора");
            while(!result) {
                string password = Console.ReadLine();
                if(password == "Sonya2005") {
                    result = true;


                } else if (password == "1") {
                    return;
                        }


                else {
                    Console.WriteLine("Неверно! Попробуйте еще раз!");

                }
            }

            Console.Clear();
            Console.WriteLine("Вход в систему успешен!");
            adminMenu();
        }
        void adminMenu() {
            bool contin = true;
            while(contin) {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Удалить предмет");
                Console.WriteLine("2 - Изменить предмет");
                Console.WriteLine("3 - Вернуться в основное меню");
                int vy = Convert.ToInt32(Console.ReadLine());
                switch(vy) {
                    case 1:
                        Console.Clear();
                        Deleteitem();
                        contin = false;
                        break;
                    case 2:
                        Console.Clear();
                        Edititem();
                        contin = false;
                        break;

                    case 3:
                        contin = false;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Ошибка, попробуйте еще раз.");
                        break;

                }

            }
        }
        void Edititem() {
            Console.WriteLine("В какой таблице вы хотите изменить значения?");
            Console.WriteLine("1 - Велосипеды");
            Console.WriteLine("2 - Аксессуары");
            int ch1 = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            using(var context = new PostgresContext(optionsBuilder.Options)) {
                switch(ch1) {
                    case 1:
                        foreach(var bicycle in context.Bicycles) {
                            Console.WriteLine($"Модель: {bicycle.Model,-10} | Тип: {bicycle.Typeb,-10} | Страна производитель: {bicycle.Countrycreator,-12} | Год производства: {bicycle.Yearc,-5} | Цена: {bicycle.Price,-5} | Номер вещи: {bicycle.Id,-5} ");
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------");
                        }
                        Console.WriteLine("Введите ID предмета для изменения:");
                        int idToChange = Convert.ToInt32(Console.ReadLine());
                        var item = context.Bicycles.Find(idToChange);
                        if(item != null) {
                            Console.WriteLine("Введите модель велосипеда:");
                            item.Model = Console.ReadLine();
                            Console.WriteLine("Введите тип велосипеда:");
                            item.Typeb = Console.ReadLine();
                            Console.WriteLine("Введите страну производителя велосипеда:");
                            item.Countrycreator = Console.ReadLine();
                            Console.WriteLine("Введите год производства велосипеда:");
                            item.Yearc = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите цену велосипеда:");
                            item.Price = Convert.ToInt32(Console.ReadLine());
                            
                            Console.WriteLine($"Предмет с ID {idToChange} изменен.");
                            context.SaveChanges();
                            
                        } else {
                            Console.WriteLine("Предмет не найден.");
                        }
                        break;
                    case 2:
                        
                        foreach(var a in context.Additionals) {

                            Console.WriteLine($"Staff - {a.Staff,-25} | Price = {a.Price,-5} | Номер вещи: {a.Id}");
                            Console.WriteLine("----------------------------------------------------");

                        }
                        Console.WriteLine("Введите ID предмета для изменения:");
                        int idToChange1 = Convert.ToInt32(Console.ReadLine());
                        var item12 = context.Additionals.Find(idToChange1);
                        if(item12 != null) {
                            Console.WriteLine("Введите название вещи: ");
                            item12.Staff = Console.ReadLine().Replace("\0", ""); 

                            Console.WriteLine("Введите цену вещи: ");
                            item12.Price = (int?)Convert.ToDecimal(Console.ReadLine());

                            context.SaveChanges();
                            Console.WriteLine($"Предмет с ID {idToChange1} изменен!.");
                            
                        } else {
                            Console.WriteLine("Предмет не найден.");
                        }
                        break;
                }

            }

        }
        void Deleteitem () {
            Console.WriteLine("Из какой таблицы вы хотите удалить значения?");
            Console.WriteLine("1 - Велосипеды");
            Console.WriteLine("2 - Аксессуары");
            int ch = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            using(var context = new PostgresContext(optionsBuilder.Options)) {
                switch(ch) {
                    case 1:
                        foreach(var bicycle in context.Bicycles) {
                            Console.WriteLine($"Модель: {bicycle.Model,-10} | Тип: {bicycle.Typeb,-10} | Страна производитель: {bicycle.Countrycreator,-12} | Год производства: {bicycle.Yearc,-5} | Цена: {bicycle.Price,-5} | Номер вещи: {bicycle.Id,-5} ");
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------");
                        }
                        
                        Console.WriteLine("Введите ID предмета для удаления:");
                        int idToDelete = Convert.ToInt32(Console.ReadLine());
                        var item = context.Bicycles.Find(idToDelete);
                        if(item != null) {
                            context.Bicycles.Remove(item);
                            context.SaveChanges();
                            Console.WriteLine($"Предмет с ID {idToDelete} удален.");
                            
                        } else {
                            Console.WriteLine("Предмет не найден.");
                        }
                        break;
                    case 2:
                        foreach(var a in context.Additionals) {

                            Console.WriteLine($"Staff - {a.Staff,-25} | Price = {a.Price,-5} | Номер вещи: {a.Id}");
                            Console.WriteLine("----------------------------------------------------");

                        }
                        Console.WriteLine("Введите ID предмета для удаления:");
                        int idToDelete1 = Convert.ToInt32(Console.ReadLine());
                        var item1 = context.Additionals.Find(idToDelete1);
                        if(item1 != null) {
                            context.Additionals.Remove(item1);
                            context.SaveChanges();
                            Console.WriteLine($"Предмет с ID {idToDelete1} удален.");
                            
                        } else {
                            Console.WriteLine("Предмет не найден.");
                        }
                        break;
                }

            }







            }
        void Velosipedy() {

            using(var context = new PostgresContext(optionsBuilder.Options)) {
                bool bicy = true; // меню где веосипеды
                
                    foreach(var bicycle in context.Bicycles) {
                        Console.WriteLine($"Модель: {bicycle.Model,-10} | Тип: {bicycle.Typeb,-10} | Страна производитель: {bicycle.Countrycreator,-12} | Год производства: {bicycle.Yearc,-5} | Цена: {bicycle.Price,-5} | Номер вещи: {bicycle.Id,-5} ");
                        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------");
                    }
                Console.WriteLine("Введите номер вещи, чтобы добавить в корзину, или 0 для возврата:");
                while(bicy) {
                    
                    int nazad = Convert.ToInt32(Console.ReadLine());

                    if(nazad == 0) {
                        bicy = false;
                        Console.Clear();
                    } else {
                        var selectedItem = context.Bicycles.FirstOrDefault(bicycle => bicycle.Id == nazad);
                        if(selectedItem != null) {
                            bas.Add(new Basket { Name = selectedItem.Model, Price = (int)selectedItem.Price });
                            Console.WriteLine($"{selectedItem.Model} {selectedItem.Typeb} добавлено в корзину.");
                        } else {
                            Console.WriteLine("Не распознали вашу команду, попробуйте еще раз.");
                        }
                    }



                }
            }
        }
        void veshi() {
            

                bool veshit = true;

               
                
                    using(var context = new PostgresContext(optionsBuilder.Options)) {
                        foreach(var a in context.Additionals) {

                            Console.WriteLine($"Staff - {a.Staff,-25} | Price = {a.Price,-5} | Номер вещи: {a.Id}");
                            Console.WriteLine("----------------------------------------------------");

                        }

                Console.WriteLine("Введите номер вещи, чтобы добавить в корзину, или 0 для возврата:");
                while(veshit) {
                    int nazad = Convert.ToInt32(Console.ReadLine());


                    if(nazad == 0) {
                        veshit = false;
                        Console.Clear();
                    } else {
                        var selectedItem = context.Additionals.FirstOrDefault(a => a.Id == nazad);
                        if(selectedItem != null) {
                            bas.Add(new Basket { Name = selectedItem.Staff, Price = (int)selectedItem.Price });
                            Console.WriteLine($"'{selectedItem.Staff}' добавлено в корзину.");
                        } else {
                            Console.WriteLine("Не распознали вашу команду, попробуйте еще раз.");
                        }
                    }
                  
                }
                }

            }
        }
  }


