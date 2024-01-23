using DesignPattern_Practice.Pattern;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static DesignPattern_Practice.Pattern.ConcreteSubject;

namespace DesignPattern_Practice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int num = 0;
        public MainWindow()
        {
            InitializeComponent();

            

            // 컨텍스트 생성 = 전략(기능) 제어용 리모컨
            var calculator = new CalculatorContext();

            // 덧셈 전략으로 설정
            calculator.SetStrategy(new AddStrategy());
            int resultAdd = calculator.PerformCalculation(5, 3);
            textbox_strategyPattern1.Text = $"덧셈 결과: {resultAdd}";


            // 곱셈 전략 변경
            calculator.SetStrategy(new MultiplyStrategy());
            int resultMultiply = calculator.PerformCalculation(5, 3);
            textbox_strategyPattern2.Text = $"곱셈 결과: {resultMultiply}";



            // 주체 생성
            var subject = new ConcreteSubject();

            // 옵저버들 생성 및 등록
            var observer1 = new ConcreteObserver("Observer 1");
            var observer2 = new ConcreteObserver("Observer 2");

            subject.RegisterObserver(observer1);
            subject.RegisterObserver(observer2);

            // 상태 변경 및 옵저버들에게 알림
            subject.State = "시작 상태";

            textbox_ObserverPattern1.Text = subject.State;
            textbox_ObserverPattern2.Text = subject.State;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var subject = new ConcreteSubject();

            // 옵저버들 생성 및 등록
            var observer1 = new ConcreteObserver("Observer 1");
            var observer2 = new ConcreteObserver("Observer 2");

            subject.RegisterObserver(observer1);
            subject.RegisterObserver(observer2);

            // 상태 변경 및 옵저버들에게 알림
            subject.State = "버튼 눌림";
            textbox_ObserverPattern1.Text = subject.State;
            textbox_ObserverPattern2.Text = subject.State;
        }
    }
}