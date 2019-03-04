using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();
            Exercise31();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }
        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            List<Product> outOfStock = new List<Product>();

            List<Product> products = DataLoader.LoadProducts();

            var onlyMT = products.Where(p => p.UnitsInStock == 0);

            //var onlyMT = from p in products
            //             where p.UnitsInStock == 0
            //             select p;

            //foreach (Product p in products) {
            //    if (p.UnitsInStock==0)
            //    {
            //        outOfStock.Add(p);

            //    }

            //}
            PrintProductInformation(onlyMT);

        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            List<Product> outOfStock = new List<Product>();

            List<Product> products = DataLoader.LoadProducts();

            var onlyMT = products.Where((p => p.UnitsInStock > 0 && p.UnitPrice > 3.0M));

            PrintProductInformation(onlyMT);
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {

            // List<Customer> customer = new List<Customer>();

            List<Customer> customer = DataLoader.LoadCustomers();

            var fromWA = customer.Where(c => c.Region == "WA");

            PrintCustomerInformation(fromWA);
            Console.ReadLine();
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            List<Product> products = DataLoader.LoadProducts();

            var queryList = from p in products
                            select new
                            {
                                p.ProductName
                            };


            foreach (var item in queryList)
            {
                Console.WriteLine(item.ProductName);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all product information 
        /// but increase the unit price by 25%
        /// </summary>
        static void Exercise5()

        {
            List<Product> products = DataLoader.LoadProducts();

            var queryList = from p in products
                            select new
                            {
                                p.ProductID,
                                p.ProductName,
                                p.Category,
                                newPrice = p.UnitPrice*1.25M,
                                p.UnitsInStock
                            };

            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var item in queryList)
            {
                Console.WriteLine(line, item.ProductID, item.ProductName, item.Category,
                    item.newPrice, item.UnitsInStock);
            }

        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName 
        /// and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            List<Product> products = DataLoader.LoadProducts();

            var queryList = from p in products
                            select new
                            {
                                upName = p.ProductName.ToUpper(),
                                upCat = p.Category.ToUpper(),
                            };

            string line = "{0,-35} {1,-35}";
            Console.WriteLine(line, "Product Name", "Category");
            Console.WriteLine("=====================================================");

            foreach (var item in queryList)
            {
                //string upName = (string)item.ProductName;
                //string upCat = (string)item.Category;

                Console.WriteLine(line, item.upName, item.upCat);

            }

        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with 
        /// an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            List<Product> products = DataLoader.LoadProducts();

            var queryList = from p in products
                            select new
                            {
                                p.ProductID,
                                p.ProductName,
                                p.Category,
                                p.UnitPrice,
                                p.UnitsInStock,
                                lessThree= (p.UnitsInStock < 3)
        };

            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5,-8}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "Reorder");
            Console.WriteLine("==============================================================================");

            bool reOrder = false;
            foreach (var item in queryList)

            {
                Console.WriteLine(line, item.ProductID, item.ProductName, item.Category,
                    item.UnitPrice, item.UnitsInStock, item.lessThree);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            List<Product> products = DataLoader.LoadProducts();

            var queryList = from p in products
                            select new
                            {
                                p.ProductID,
                                p.ProductName,
                                p.Category,
                                p.UnitPrice,
                                p.UnitsInStock,
                                StockVal= p.UnitPrice * p.UnitsInStock
                            };

            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,7} {5,-12:c}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "StockValue");
            Console.WriteLine("==============================================================================");

            foreach (var item in queryList)

            {
                Console.WriteLine(line, item.ProductID, item.ProductName, item.Category,
                    item.UnitPrice, item.UnitsInStock, item.StockVal);
            }

        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            var num = DataLoader.NumbersA;

            var onlyEvens = num.Where(n => n % 2 == 0);

            foreach (int n in onlyEvens)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            List<Customer> customer = DataLoader.LoadCustomers();
            ////decimal average = students.Average(s => s.GPA);
            //string line = "{0,-25} {1,-35} {2,-15} {3,6:c}";
            //Console.WriteLine(line, "ID", "Company Name", "Country", "Address", "City", "Total Purchase");
            //Console.WriteLine("==============================================================================");

            //var lowNums =
            //   from n in numbers
            //   where n < 5
            //   select n;


            var lowOrderCusts =
                from c in customer
                from o in c.Orders
                where o.Total < 500.00M
                select new { c.CustomerID, o.OrderID, o.Total };


            //var lowOrderCusts =
            //    from c in customer
            //    let orderSum = c.Orders.Sum(o => o.Total)
            //    where orderSum < 500
            //    select c;

            foreach (var item in lowOrderCusts)

            {
                var printLine = string.Join(",", item.CustomerID, item.OrderID, item.Total);
                Console.WriteLine(printLine);
            } 

        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            var num = DataLoader.NumbersC;

            var onlyOdds = num.Where(n => n % 2 != 0).Take(3);

            foreach (int n in onlyOdds)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            var num = DataLoader.NumbersB.Skip(3);

            foreach (int n in num)
            {
                Console.WriteLine(n);
            }

        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {

            List<Customer> customer = DataLoader.LoadCustomers();

            var fromWA = customer.Where(c => c.Region == "WA");

            foreach (var WaComp in fromWA)
            {
                //var sortedOrders = WaComp.Orders.OrderBy(n => n);
                var recentOrder = WaComp.Orders.OrderBy(n => n.OrderDate).FirstOrDefault();

                //var recentOrder = sortedOrders.First();
                Console.WriteLine(WaComp.CompanyName);
                Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", 
                    recentOrder.OrderID, recentOrder.OrderDate, recentOrder.Total);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            var num = DataLoader.NumbersC;

            var onlyEvens = num.Where(n => n >= 6);

            foreach (int n in onlyEvens)
            {
                Console.WriteLine(n);
            }

        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number 
        /// divisible by 3
        /// </summary>
        static void Exercise15()
        {
            var num = DataLoader.NumbersC;

            var skipNums = num.SkipWhile(n => n % 3!=0).Skip(1);
            
            foreach (var aNum in skipNums)
            {
                Console.WriteLine(aNum);
            }
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            List<Product> products = DataLoader.LoadProducts();

            var orderByName = products.OrderBy(n => n.ProductName);

            foreach (Product prdct in orderByName)
            {
                Console.WriteLine(prdct.ProductName);
            }
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            List<Product> products = DataLoader.LoadProducts();

            var orderByUnits = products.OrderByDescending(n => n.UnitsInStock);

            foreach (Product prdct in orderByUnits)
            {
                Console.Write(prdct.ProductName + ", ");
                Console.WriteLine(prdct.UnitsInStock);
            }
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, 
        /// from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            List<Product> products = DataLoader.LoadProducts();

            var orderByUnits = products.OrderBy(n => n.Category).
                ThenBy(n => n.UnitPrice).ThenByDescending(n => n.UnitsInStock);

            string line = "{0,-35} {1,-15} {2,6:c} {3,5}";
            foreach (Product item in orderByUnits)
            {
                Console.WriteLine(line, item.ProductName, item.Category,
                    item.UnitPrice, item.UnitsInStock);
            }

        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {

            var num1 = DataLoader.NumbersB.Reverse();
            var num = DataLoader.NumbersB;

            foreach (int n in num)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();
            foreach (int n in num1)
            {
                Console.WriteLine(n);
            }

        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {

            List<Product> products = DataLoader.LoadProducts();

            var groupedProd = from product in products
                              group product by product.Category into result
                              select new
                              {
                                  Key=result.Key,
                                  Contents = result
                                  //anony type allows us to interate over products in a Category
                                  //Analyze further.
                              };

            foreach (var group in groupedProd)
            {
                Console.WriteLine(group.Key);
                foreach (var prdct in group.Contents)
                {
                    Console.WriteLine("\t{0}", prdct.ProductName);
                }

            }

        }

        /// <summary>
        /// Don't do 21. ////
        /// 
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// Don't do 21. ////
        /// </summary>
        static void Exercise21DontDo()
        {
            /// Don't do 21. ////
        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            List<Product> products = DataLoader.LoadProducts();
            //string crntCat = "";
            var prodCats = from p in products
                           select p.Category;

            var uniqueCats = prodCats.Distinct();

            foreach (string sortCat in uniqueCats)
            {
                Console.WriteLine(sortCat);
            }
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            List<Product> products = DataLoader.LoadProducts();
            Product find789 = products.FirstOrDefault(p => p.ProductID == 789);

            foreach (Product product in products)
            {
                if (find789 == null)
                { Console.WriteLine("789 does not exist."); }
                else
                { Console.WriteLine("789 does exist."); }
            }
        }


        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            List<Product> products = DataLoader.LoadProducts();
            var sortedCats = products.OrderBy(c => c.Category);


            var prodCats = from p in products
                           where p.UnitsInStock == 0
                           select p.Category;
            
            var uniqueCats = prodCats.Distinct();

            foreach (string cat in uniqueCats)
            {
                Console.WriteLine(cat);
            }
            
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {

            List<Product> products = DataLoader.LoadProducts();
            var sortedCats = products.OrderBy(c => c.Category);

            var prodCats = from p in products
                           where p.UnitsInStock != 0
                           select p.Category;

            var uniqueCats = prodCats.Distinct();

            foreach (string cat in uniqueCats)
            {
                Console.WriteLine(cat);
            }
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            {
                int countA = 0;
                var num = DataLoader.NumbersA;
                var onlyOdds = num.Where(n => n % 2 != 0);

                countA = onlyOdds.Count();
                Console.WriteLine(countA);
            }
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the 
        /// count of their orders
        /// </summary>
        static void Exercise27()
        {
            List<Customer> customers = DataLoader.LoadCustomers();

            var queryList = from c in customers
                            select new
                            {
                                c.CustomerID,
                                orders=c.Orders.Count()
                            };

            foreach (var item in queryList)
            {
                Console.WriteLine(item.CustomerID + ", " + item.orders);
            }

        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products 
        /// they contain
        /// </summary>
        static void Exercise28()
        {

            List<Product> products = DataLoader.LoadProducts();

            var queryList = from p in products
                            group p by p.Category into g
                            select new
                            {
                                Category=g.Key,
                                prods=g.Count()
                            };

            foreach (var item in queryList)
            {
                Console.WriteLine(item.Category + ", " + item.prods);
            }

        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            List<Product> products = DataLoader.LoadProducts();

            var queryList = from p in products
                            group p by p.Category into g
                            select new
                            {
                                Category = g.Key,
                                totalUnits = g.Sum(s=>s.UnitsInStock)
                            };

            foreach (var item in queryList)
            {
                Console.WriteLine(item.Category + ", " + item.totalUnits);
            }

        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest 
        /// priced product in that category
        /// </summary>
        static void Exercise30()
        {

            List<Product> products = DataLoader.LoadProducts();

            var queryList = from p in products
                            group p by p.Category into g
                            select new
                            {
                                Category = g.Key,
                                totalUnits = g.Min (s => s.UnitsInStock)
                            };

            foreach (var item in queryList)
            {
                Console.WriteLine(item.Category + ", " + item.totalUnits);
            }
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            List<Product> products = DataLoader.LoadProducts();

            var queryList = from p in products
                            group p by p.Category into g
                            select new
                            {
                                Category = g.Key,
                                aveCost = g.Average (s => s.UnitPrice)
                            };

            var sortedByPrice = queryList.OrderByDescending(p => p.aveCost).Take(3);
                
                foreach (var item in sortedByPrice)
            {
                Console.WriteLine(item.Category + ", " + item.aveCost);
            }
        }

    }

}

