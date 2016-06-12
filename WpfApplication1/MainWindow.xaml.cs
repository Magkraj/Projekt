using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
using WpfApplication1;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Animal> _animals = new ObservableCollection<Animal>();
        private ObservableCollection<Dog> _dogs = new ObservableCollection<Dog>();
        private ObservableCollection<Cat> _cats = new ObservableCollection<Cat>();
        private ObservableCollection<Bird> _birds = new ObservableCollection<Bird>();
        public ObservableCollection<Animal> Animals => _animals;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            _animals.CollectionChanged += UpdateAnimalList;
        }

        private void UpdateAnimalList(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            _dogs.Clear();
            _cats.Clear();
            _birds.Clear();
            foreach (Animal animal in _animals)
            {
                if (animal.GetType() == typeof(Dog))
                    _dogs.Add((Dog)animal);
                else if (animal.GetType() == typeof(Cat))
                    _cats.Add((Cat)animal);
                else if (animal.GetType() == typeof(Bird))
                    _birds.Add((Bird)animal);
            }
        }

        private void TextBoxNameAdd_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxNameAdd.Text = "";
        }

        private void TextBoxNameAdd_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameAdd.Text == "")
                TextBoxNameAdd.Text = "Imie zwierzaka";
        }

        private void TextBoxLastNameAdd_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxLastNameAdd.Text = "";
        }

        private void TextBoxLastNameAdd_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxLastNameAdd.Text == "")
                TextBoxLastNameAdd.Text = "Nazwisko wlasciciela";
        }

        private void TextBoxAgeAdd_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxAgeAdd.Text = "";
        }

        private void TextBoxAgeAdd_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxAgeAdd.Text == "")
                TextBoxAgeAdd.Text = "Wiek";
        }

        private void TextBoxRaceAdd_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxRaceAdd.Text = "";
        }

        private void TextBoxRaceAdd_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxRaceAdd.Text == "")
                TextBoxRaceAdd.Text = "Rasa";
        }

        private void TextBoxLookAdd_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxLookAdd.Text = "";
        }

        private void TextBoxLookAdd_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxLookAdd.Text == "")
                TextBoxLookAdd.Text = "Opis wygladu";
        }

        private void TextBoxNameEdit_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxNameEdit.Text = "";
        }

        private void TextBoxNameEdit_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameEdit.Text == "")
                TextBoxNameEdit.Text = "Imie zwierzaka";
        }

        private void TextBoxLastNameEdit_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxLastNameEdit.Text = "";
        }

        private void TextBoxLastNameEdit_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxLastNameEdit.Text == "")
                TextBoxLastNameEdit.Text = "Nazwisko wlasciciela";
        }

        private void TextBoxAgeEdit_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxAgeEdit.Text = "";
        }

        private void TextBoxAgeEdit_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxAgeEdit.Text == "")
                TextBoxAgeEdit.Text = "Wiek";
        }

        private void TextBoxRaceEdit_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxRaceEdit.Text = "";
        }

        private void TextBoxRaceEdit_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxRaceEdit.Text == "")
                TextBoxRaceEdit.Text = "Rasa";
        }

        private void TextBoxLookEdit_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxLookEdit.Text = "";
        }

        private void TextBoxLookEdit_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxLookEdit.Text == "")
                TextBoxLookEdit.Text = "Opis wygladu";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var name = TextBoxLookAdd.Text;
                var ownerName = TextBoxLastNameAdd.Text;
                int age = Int32.Parse(TextBoxAgeAdd.Text);
                var race = TextBoxRaceAdd.Text;
                var look = TextBoxLookAdd.Text;
                int count = 0;
                int count2 = 0;
                if (DogButton.IsChecked == true)
                    _animals.Add(new Dog(name, ownerName, age, race, look, count, count2));
                else if (CatButton.IsChecked == true)
                    _animals.Add(new Cat(name, ownerName, age, race, look, count, count2));
                else
                {
                    _animals.Add(new Bird(name, ownerName, age, race, look, count, count2));
                }
                if (_animals.Count == 1)
                {
                    ComboBoxEdit.SelectedIndex = 0;
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Niepoprawny wiek!");
            }
        }

        private void ComboBoxDog_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxDog.ItemsSource = _dogs;
        }

        private void ComboBoxCat_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxCat.ItemsSource = _cats;
        }

        private void ComboBoxBird_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxBird.ItemsSource = _birds;
        }

        private void ComboBoxEdit_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxEdit.ItemsSource = Animals;
        }

        private void ButtonNameEdit_Click(object sender, RoutedEventArgs e)
        {
            Animal animal = (Animal) ComboBoxEdit.SelectedItem;
            {
                animal.AnimalName = TextBoxLookEdit.Text;

                CollectionViewSource.GetDefaultView(this.Animals).Refresh();
                ComboBoxEdit.SelectedItem = null;
                ComboBoxEdit.SelectedItem = animal;
            }

        }

        private void ButtonLastNameEdit_Click(object sender, RoutedEventArgs e)
        {
            Animal animal = (Animal) ComboBoxEdit.SelectedItem;

            animal.OwnerName = TextBoxLastNameEdit.Text;

            CollectionViewSource.GetDefaultView(this.Animals).Refresh();
            ComboBoxEdit.SelectedItem = null;
            ComboBoxEdit.SelectedItem = animal;
        }

        private void ButtonAgeEdit_Click(object sender, RoutedEventArgs e)
        {
            Animal animal = (Animal)ComboBoxEdit.SelectedItem;

            animal.AnimalAge = Int32.Parse(TextBoxAgeEdit.Text);

            CollectionViewSource.GetDefaultView(this.Animals).Refresh();
            ComboBoxEdit.SelectedItem = null;
            ComboBoxEdit.SelectedItem = animal;
        }

        private void ButtonRaceEdit_Click(object sender, RoutedEventArgs e)
        {
            Animal animal = (Animal)ComboBoxEdit.SelectedItem;

            animal.AnimalRace = TextBoxRaceEdit.Text;

            CollectionViewSource.GetDefaultView(this.Animals).Refresh();
            ComboBoxEdit.SelectedItem = null;
            ComboBoxEdit.SelectedItem = animal;
        }

        private void ButtonLookEdit_Click(object sender, RoutedEventArgs e)
        {
            Animal animal = (Animal)ComboBoxEdit.SelectedItem;

            animal.AnimalLook = TextBoxLookEdit.Text;

            CollectionViewSource.GetDefaultView(this.Animals).Refresh();
            ComboBoxEdit.SelectedItem = null;
            ComboBoxEdit.SelectedItem = animal;
        }

        private void ButtonLock_Click(object sender, RoutedEventArgs e)
        {

                Animal animal = (Animal)ComboBoxEdit.SelectedItem;

                animal.LockVisit();
            
        }

        private void ButtonUnlock_Click(object sender, RoutedEventArgs e)
        {

                Animal animal = (Animal)ComboBoxEdit.SelectedItem;

                animal.UnlockVisit();
    
        }

        private void ButtonAddDogCount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Animal animal = (Animal) ComboBoxDog.SelectedItem;

                animal.NewVisit();
                TextblockDogCount.Text = animal.AnimalCount.ToString();
            }
            catch (LockException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Wybierz zwierzaka");
            }
        }

        private void ButtonAddDogCount2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Animal animal = (Animal) ComboBoxDog.SelectedItem;

                animal.NewTreatment();
                TextblockDogCount2.Text = animal.AnimalCount2.ToString();
            }
            catch (LockException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Wybierz zwierzaka");
            }
        }

        private void ButtonAddCatCount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Animal animal = (Animal)ComboBoxCat.SelectedItem;

                animal.NewVisit();
                TextblockCatCount.Text = animal.AnimalCount.ToString();
            }
            catch (LockException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Wybierz zwierzaka");
            }
        }

        private void ButtonAddCatCount2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Animal animal = (Animal)ComboBoxCat.SelectedItem;

                animal.NewTreatment();
                TextblockCatCount2.Text = animal.AnimalCount2.ToString();
            }
            catch (LockException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Wybierz zwierzaka");
            }

        }

        private void ButtonAddBirdCount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Animal animal = (Animal)ComboBoxBird.SelectedItem;

                animal.NewVisit();
                TextblockBirdCount.Text = animal.AnimalCount.ToString();
            }
            catch (LockException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Wybierz zwierzaka");
            }
        }

        private void ButtonAddBirdCount2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Animal animal = (Animal)ComboBoxBird.SelectedItem;

                animal.NewTreatment();
                TextblockBirdCount2.Text = animal.AnimalCount2.ToString();
            }
            catch (LockException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Wybierz zwierzaka");
            }
        }

        private void ComboBoxDog_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Animal animal = (Animal) ComboBoxDog.SelectedItem;
            TextblockDogCount.Text = animal.AnimalCount.ToString();
            TextblockDogCount2.Text = animal.AnimalCount2.ToString();
        }

        private void ComboBoxCat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Animal animal = (Animal)ComboBoxCat.SelectedItem;
            TextblockCatCount.Text = animal.AnimalCount.ToString();
            TextblockCatCount2.Text = animal.AnimalCount2.ToString();
        }

        private void ComboBoxBird_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Animal animal = (Animal)ComboBoxBird.SelectedItem;
            TextblockBirdCount.Text = animal.AnimalCount.ToString();
            TextblockBirdCount2.Text = animal.AnimalCount2.ToString();
        }
    }
}
