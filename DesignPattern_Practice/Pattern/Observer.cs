using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesignPattern_Practice.Pattern
{

    // 상태가 변경되는 주체. 실제 값을 받아 쓰는 기능들을 등록
    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    // 옵저버. 값이 변경이 됨이 감지하면 작동
    public interface IObserver
    {
        void Update(string message);
    }

    // 주체의 기능
    public class ConcreteSubject : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        private string _state = "";

        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                NotifyObservers();
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_state);
            }
        }
        
        // 옵저버의 기능
        public class ConcreteObserver : IObserver
        {
            private string _observerName;

            public ConcreteObserver(string observerName)
            {
                _observerName = observerName;
            }

            public void Update(string message)
            {
                MessageBox.Show($"{_observerName} 가 업데이트 되었습니다. : {message}");
            }
        }

    }


}
