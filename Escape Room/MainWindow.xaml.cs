using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Escape_Room
{
    struct Item
    {
        char symbol;
        string name;
        string discription;
        public bool canBeUsed;
        public Item(string _name, string _discription)
        {
            name = _name;
            discription = _discription;
            canBeUsed = true;
            symbol = (char)name[0];

        }
        public override string ToString()
        {
            return symbol.ToString();
        }
        public void used() { canBeUsed = false; }
        public void Focused()
        {
            MessageBox.Show($"{name}:\n {discription}");
        }
    }
    struct Inventory
    {
        List<Item> items = new List<Item>();
        public Inventory()
        {

        }
        public void display()
        {
            string toOutput = "";
            foreach (Item item in items)
            {
                if (item.canBeUsed)
                {
                    toOutput += item;
                }
            }
            MessageBox.Show(toOutput.Length == 0 ? "No Items" : toOutput);
        }
        public void add(Item item)
        {
            items.Add(item);
        }
    }
    class Player
    {
        public Inventory inventory;
        // dont allow the user to change the username, just read it
        public string username { get; }
        // dont allow the user to get or set the password
        protected string password;
        public Player(string _username, string _password)
        {
            // create the users inventory  as a list of items
            inventory = new Inventory();
            username = _username;
            password = _password;
        }
        public bool passwordCorrect(string entered_password)
        {
            // return if the accounts password equals the password given
            return password == entered_password;
        }
    }
    struct Game
    {
        bool loggedIn;
        public Player player;
        public Game(string _username, string _password)
        {
            loggedIn = true;
            player = new Player(_username, _password);
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Game game = new Game(Username_Box.Text, Password_Box.Password);
            Item itemToAdd = new Item("Test", "This is a test item");
            game.player.inventory.add(itemToAdd);
            game.player.inventory.display();
        }
    }
}
