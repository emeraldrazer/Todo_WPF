using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
using System.IO;
using System.Windows.Controls.Primitives;

namespace TodoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private List<StackPanel> stackPanels = new List<StackPanel>();
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\todos.json";

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MyWindow_Loaded;
        }

        private void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(path))
            {
                string[] todos = File.ReadAllLines(path);

                foreach (string line in todos)
                {
                    Todo todo = JsonSerializer.Deserialize<Todo>(line);
                    AddTodo(todo.TaskName, todo.TaskDescription, todo.DueDate, todo.Finished);
                }
            }
            else
            {
                File.Create(path);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddTodo(taskName.Text, taskDescription.Text, taskDate.Text, false);

            var todo = new
            {
                TaskName = taskName.Text,
                TaskDescription = taskDescription.Text,
                DueDate = taskDate.Text,
                Finished = false
            };

            string json = JsonSerializer.Serialize(todo);

            File.AppendAllText(path, $"{json}\n");

        }

        private void AddTodo(string name, string description, string duedate, bool finished)
        {
            name = name.Replace(" ", "");

            CheckBox checkBox = new CheckBox();
            checkBox.IsChecked = finished;
            checkBox.Checked += (sender, e) => { CheckBox_Checked(sender, e, name, true); };
            checkBox.Unchecked += (sender, e) => { CheckBox_Unchecked(sender, e, name, false); };
            checkBox.HorizontalAlignment = HorizontalAlignment.Left;
            checkBox.Content = "Finished";
            checkBox.Name = name;
            checkBox.FontSize = 15;
            checkBox.Margin = new Thickness(10);

            Button button = new Button();
            button.Cursor = Cursors.Hand;
            button.Content = "Remove";
            button.Click += (sender, e) => { RemoveBTN(sender, e, name); };
            button.Width = 50;
            button.Height = 20;
            button.HorizontalAlignment = HorizontalAlignment.Left; 

            StackPanel stackPanel1 = new StackPanel();
            stackPanel1.Margin = new Thickness(20, 0, 0, 0);

            TextBlock textBlock2 = new TextBlock();
            textBlock2.Text = $"Title: {name}";
            textBlock2.FontSize = 15;
            textBlock2.TextWrapping = TextWrapping.Wrap;

            TextBlock textBlock = new TextBlock();
            textBlock.Text = $"Description: {description}";
            textBlock.FontSize = 15;
            textBlock.TextWrapping = TextWrapping.Wrap;

            StackPanel stackPanel2 = new StackPanel();
            stackPanel2.Orientation = Orientation.Horizontal;

            TextBlock dueDateTextBlock = new TextBlock();
            dueDateTextBlock.Text = "Due Date: ";
            dueDateTextBlock.FontSize = 15;

            TextBlock datePicker = new TextBlock();
            datePicker.FontSize = 15;
            datePicker.Text = duedate;

            stackPanel2.Children.Add(dueDateTextBlock);
            stackPanel2.Children.Add(datePicker);

            stackPanel1.Children.Add(checkBox);
            stackPanel1.Children.Add(textBlock2);
            stackPanel1.Children.Add(textBlock);
            stackPanel1.Children.Add(stackPanel2);
            stackPanel1.Children.Add(button);

            parentStackPanel.Children.Add(stackPanel1);
            
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e, string name, bool isfinished)
        {
            MarkTodo(name, isfinished);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e, string name, bool isfinished)
        {
            MarkTodo(name, isfinished);
        }

        private void RemoveBTN(object sender, RoutedEventArgs e, string name)
        {
            RemoveTodo(name);
        }

        private void MarkTodo(string name, bool isfinished)
        {
            string[] todos = File.ReadAllLines(path);
            
            foreach (var child in parentStackPanel.Children)
            {
                if (child is StackPanel stackpanel)
                {
                    CheckBox checkbox = stackpanel.Children.OfType<CheckBox>().FirstOrDefault();
                    if (checkbox != null && checkbox.IsChecked == isfinished && checkbox.Name == name)
                    {
                        File.WriteAllText(path, String.Empty);

                        foreach (string line in todos)
                        {
                            using(StreamWriter write = new StreamWriter(path, true))
                            {
                                if (!line.Contains(name))
                                {
                                    write.WriteLine(line);
                                }
                                else
                                {
                                    Todo Djson = JsonSerializer.Deserialize<Todo>(line);

                                    var todo = new
                                    {
                                        TaskName = Djson.TaskName,
                                        TaskDescription = Djson.TaskDescription,
                                        DueDate = Djson.DueDate,
                                        Finished = isfinished
                                    };

                                    string json = JsonSerializer.Serialize(todo);

                                    write.WriteLine(json);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void RemoveTodo(string name)
        {
            foreach (var child in parentStackPanel.Children)
            {
                if(child is StackPanel stackpanel)
                {
                    TextBlock textBlock = stackpanel.Children.OfType<TextBlock>().FirstOrDefault();
                    if(textBlock != null && textBlock.Text.Contains(name))
                    {
                        stackPanels.Add(stackpanel);
                    }
                }
            }

            foreach (var item in stackPanels)
            {
                parentStackPanel.Children.Remove(item);
            }

            string[] todos = File.ReadAllLines(path);

            using(StreamWriter writer = new StreamWriter(path))
            {
                foreach (string line in todos)
                {
                    if (!line.Contains(name))
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}