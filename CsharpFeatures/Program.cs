
using CsharpFeatures;
using System.Collections.ObjectModel;
using System.Drawing;


#region Feature1: Records
var Orange = new Fruits("Orange", 4.34);
//We Can't change the value. It can be instatiated when it was created
//Orange.Rate = 5.6;

//We can create a copy using With operator
//This is called Non-Destructive Mutation
var orangeWithDiscount = Orange with { Rate = 5.6 };
#endregion

#region Switch Expression
KnownColor color = KnownColor.Green;

var selectedColor = color switch
{
    KnownColor.Red => "Red",
    KnownColor.Green => "Green",
    _ => "Unknown value"
};
Console.WriteLine($"The User selected {selectedColor}");
#endregion


//string longMessage = """
//                    This is the message with long message  """;

//Uses Body Expression constructor to popuate the Property
User user = new User("Manimaran", 35);

#region call functions which contains Local fun

#endregion

#region Local function inside a method
IEnumerable<string> SequenceToLower(IEnumerable<string> collection)
{
    if (!collection.Any())
    {
        throw new ArgumentException();
    }
    return collection.Select(ToLower);
    string ToLower(string value)
    {
        return value.ToLowerInvariant();
    }
}

//Another Example
IEnumerable<string> ReadFileLineByLine(string fileName)
{
    if(string.IsNullOrEmpty(fileName)|| !File.Exists(fileName))
    {
        throw new FileNotFoundException($"Unable to Locate the file {fileName}");
    }
    return ReadFileLines();

    //InLine Function
    IEnumerable<string> ReadFileLines()
    {
        foreach(var line in File.ReadAllLines(fileName))
        {
            yield return line;
        }
    }
}
#endregion

#region String Interpolation
string firstName = "Mani";
string lastName = "Maran";
string fullName = string.Empty;
//using String concat
//fullName= firstName + " " +lastName;

//using String Interpolation
fullName = $"{firstName} {lastName}";
#endregion

#region Return Readonly collection

var products = GetProducts();
//We can't make change to the products

ReadOnlyCollection<Product> GetProducts()
{
    List<Product> products = new List<Product>();
    products.Add(new Product()
    {
        Id = 1,
        Name = "A",
        Price = 10.2
    });
    products.Add(new Product()
    {
        Id = 2,
        Name = "B",
        Price = 3.4
    });

    //Return Readonly Products
    ReadOnlyCollection<Product> readOnlyProducts = new ReadOnlyCollection<Product>(products);

    return readOnlyProducts;
}
#endregion


#region Required Keyword on Property

public class Blog
{
    public required string Title { get; set; }
    public string Description { get; set; }
}
#endregion


