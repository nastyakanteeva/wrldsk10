// Класс ClassEvent представляет класс, который может вызывать события
class ClassEvent
{
    // Событие Event представляет действие, которое вызывается при наступлении события
    public event Action<string> Event;

    // Свойство Message хранит сообщение, которое будет отправлено при наступлении события
    public string Message { get; set; }

    // Конструктор класса ClassEvent принимает сообщение, которое будет отправлено при наступлении события
    public ClassEvent(string message)
    {
        Message = message;
    }

    // Метод TriggerEvent вызывает событие Event, отправляя сообщение
    public void TriggerEvent()
    {
        // Проверка, подписан ли кто-нибудь на событие. Если да, вызывает событие и отправляет сообщение.
        Event?.Invoke(Message);
    }
}

// Класс ProcessingEvent представляет класс, который обрабатывает события
class ProcessingEvent
{
    // Метод ProcessinEvent обрабатывает сообщение, отправленное при наступлении события
    public void ProcessinEvent(string message)
    {
        Console.WriteLine($"Событие - {message}");
    }
}

// Класс Program представляет точку входа в приложение
class Program
{
    static void Main()
    {
        // Создание экземпляра класса ProcessingEvent для обработки событий
        ProcessingEvent handler = new();

        // Создание двух экземпляров класса ClassEvent для вызова событий
        ClassEvent object1 = new("Объект 1");
        ClassEvent object2 = new("Объект 2");

        // Подписка на событие Event объектов object1 и object2
        object1.Event += handler.ProcessinEvent;
        object2.Event += handler.ProcessinEvent;

        // Вызов события Event для объектов object1 и object2
        object1.TriggerEvent();
        object2.TriggerEvent();
    }
}