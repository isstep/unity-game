using System;

namespace LR4
{
    public class Massiv
    {
        // Приватное поле для хранения массива
        private double[] _elements;

        // Свойство для получения длины массива
        public int Length => _elements.Length;

        // Индексатор для доступа к элементам массива
        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= _elements.Length)
                    throw new IndexOutOfRangeException("Индекс находится вне границ массива");
                return _elements[index];
            }
            set
            {
                if (index < 0 || index >= _elements.Length)
                    throw new IndexOutOfRangeException("Индекс находится вне границ массива");
                _elements[index] = value;
            }
        }

        // Конструктор с длиной массива
        public Massiv(int length)
        {
            if (length <= 0)
                throw new ArgumentException("Длина массива должна быть положительным числом");
            _elements = new double[length]; // Инициализация массива заданной длины
        }

        // Конструктор с начальным массивом значений
        public Massiv(double[] initialValues)
        {
            if (initialValues == null)
                throw new ArgumentNullException(nameof(initialValues), "Массив не может быть null");
            _elements = (double[])initialValues.Clone(); // Клонирование массива для предотвращения изменений исходного массива
        }

        // Метод для подсчета количества отрицательных элементов
        public int CountNegativeElements()
        {
            int count = 0;
            foreach (double value in _elements)
            {
                if (value < 0)
                    count++; // Увеличиваем счетчик для каждого отрицательного элемента
            }
            return count;
        }

        // Метод для подсчета количества элементов после указанного индекса
        public int CountElementsAfter(int index)
        {
            if (index < 0 || index >= _elements.Length)
                throw new IndexOutOfRangeException("Индекс находится вне границ массива");
            return _elements.Length - index - 1; // Возвращает количество элементов после указанного индекса
        }

        // Метод для подсчета количества отрицательных элементов, больших заданного значения
        public int CountNegativeElementsGreaterThan(double threshold)
        {
            int count = 0;
            foreach (double value in _elements)
            {
                if (value < 0 && value > threshold) // Проверка на отрицательность и превышение порога
                    count++;
            }
            return count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Пример использования класса Massiv

            // Создание массива с заданной длиной
            Massiv massiv1 = new Massiv(5);
            massiv1[0] = -1.5;
            massiv1[1] = 2.3;
            massiv1[2] = -0.7;
            massiv1[3] = 4.1;
            massiv1[4] = -3.2;

            // Вывод количества отрицательных элементов
            Console.WriteLine($"Количество отрицательных элементов: {massiv1.CountNegativeElements()}");

            // Создание массива с начальными значениями
            double[] initialValues = { -1.5, 2.3, -0.7, 4.1, -3.2 };
            Massiv massiv2 = new Massiv(initialValues);

            // Вывод количества элементов после индекса 2
            Console.WriteLine($"Количество элементов после индекса 2: {massiv2.CountElementsAfter(2)}");

            // Вывод количества отрицательных элементов, которые больше -2
            Console.WriteLine($"Количество отрицательных элементов больше -2: {massiv2.CountNegativeElementsGreaterThan(-2)}");

            Console.ReadLine(); // Ожидание нажатия клавиши для завершения программы
        }
    }
}
