using System.Reflection;

class Program {
    static void Main(string[] args) {
        //lấy assemply của program hiện tại
        var assembly = Assembly.GetExecutingAssembly();
        // tên của assembly, version hiện tại của assembly, culture, public key token
        Console.WriteLine(assembly);

        //lấy type của assembly
        var types = assembly.GetTypes();
        foreach (var type in types) { 
            //lấy name của các type
            Console.WriteLine("Type: " + type.Name);

            //lấy properties của các type
            var props = type.GetProperties();
            foreach (var prop in props) {
                //lấy name và type của các properties trong class
                Console.WriteLine("\tProperty Name: " + prop.Name + "\tProperty Type: " + prop.PropertyType);
            }

            var fields = type.GetFields();
            foreach (var field in fields) {
                //name của các field trong class
                Console.WriteLine("\tField Name: " + field.Name);
            }

            var methods = type.GetMethods();
            foreach (var method in methods) {
                //name của các method trong class
                Console.WriteLine("\tMethod Name: " + method.Name);
            }
        }

        //demo cách ứng dụng reflection
        //gán giá trị cho class demo
        var demo = new Demo { Name = "Trung", Age = 24 };
        //gọi type của class demo
        var demoType = typeof(Demo); //==demo.GetType();
        //gọi property của class demo
        var demoProperty = demoType.GetProperty("Name");
        Console.WriteLine("Property: " + demoProperty.GetValue(demo));
        //gọi field của class demo
        var demoField = demoType.GetField("Age");
        Console.WriteLine("Field: " + demoField.GetValue(demo));
        //gọn method của class demo
        var demoMethod = demoType.GetMethod("MyMethod");
        //execute method trong class demo
        demoMethod.Invoke(demo, null);
    }
}
public class Demo
{
    public string Name { get; set; }
    public int Age;

    public void MyMethod()
    {
        Console.WriteLine("Hello World!");
    }
}