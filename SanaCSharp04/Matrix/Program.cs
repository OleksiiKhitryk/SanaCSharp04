using Matrix;

Console.WriteLine("Enter please the dimension of array[rows, columns]");
Console.Write("rows = ");
uint rows = uint.Parse(Console.ReadLine());
Console.Write("columns = ");
uint columns = uint.Parse(Console.ReadLine());

double[,] matrix = MatrixMethod.MatrixRandomDataFill(rows, columns);
MatrixMethod.WriteMatrixOnTerminal(matrix);

int quantityPositiveElementInArray = 0;                             //кількість додатних елементів
for (int j = 0; j < columns; j++)                           
{
    for (int i = 0; i < rows; i++)
    {
        if (matrix[i, j] > 0)                               
            quantityPositiveElementInArray++;
    }
}
if (quantityPositiveElementInArray > 0)
    Console.WriteLine($"Quantity positive element in array = {quantityPositiveElementInArray}");
else
    Console.WriteLine("Positive elements in array are absent");

double maxValue = double.MinValue;                                  // максимальне із чисел, що зустрічається
int maxValueQuantity = 0;                                           // в заданій матриці більше одного разу
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns - 1; j++)
    {
        if (maxValue <= matrix[i, j])
            maxValue = matrix[i, j];
        if (maxValue == matrix[i, j + 1])
            maxValueQuantity++;
    }
}
if (maxValueQuantity > 1)
{
    Console.WriteLine($"Max value in matrix = {maxValue}");
    Console.WriteLine($"Max value quantity in matrix  = {maxValueQuantity}");
}
else
    Console.WriteLine("Max value in array comes just one time");

int notNullElement, RowQuantityWithoutNullElements = 0;              //кількість рядків, які не містять жодного нульового елемента
for (int i = 0; i < rows; i++)
{
    notNullElement = 0;
    for (int j = 0; j < columns; j++)
        {
        if (matrix[i, j] > 0 || matrix[i, j] < 0)                              
            notNullElement++;
    }
    if (notNullElement == rows)                           
        RowQuantityWithoutNullElements++;
}
if (RowQuantityWithoutNullElements > 0)                        
    Console.WriteLine($"Row quantity without null elements = {RowQuantityWithoutNullElements}");
else if (RowQuantityWithoutNullElements == 0)
    Console.WriteLine("In all rows present one or more null element");

int nullElements, ColumnQuantityWithNullElements = 0;                //кількість стовпців, які містять хоча б один нульовий елемент
for (int i = 0; i < rows; i++) 
{
    nullElements = 0;
    for (int j = 0; j < columns; j++)
    {
        if (matrix[i, j] == 0)                              
            nullElements++;
    }
    if (nullElements >= 1)
        ColumnQuantityWithNullElements++;
}
if (ColumnQuantityWithNullElements > 0)
    Console.WriteLine($"Column quantity with null elemens = {ColumnQuantityWithNullElements}");
else if (ColumnQuantityWithNullElements == 0)
    Console.WriteLine("Column with null elemens are absent");

int equalElements;                                                 //номер рядка, в якому знаходиться найдовша 
for (int i = 0; i < rows; i++)                                     //серія однакових елементів
{
    equalElements = 0;
    for (int j = 0; j < columns - 1; j++)
    {
        if (matrix[i, j] == matrix[i, j + 1])
            equalElements++;
    }
    if (equalElements > 0)
        Console.WriteLine($"Row number of serial equal elements {i}");
}

int quantityRowsWherePresentNegative = 0;                           //добуток елементів в тих рядках, 
int quantityPositiveElementInRow = 0;                               //які не містять від’ємних елементів
double multiplyRowElement = 1;                                      
double[] multiplyRowElementOfMatrix = new double[rows];
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        if (matrix[i, j] > 0)
        {
            multiplyRowElement *= matrix[i, j];
            quantityPositiveElementInRow++;
        }
        else if (matrix[i, j] < 0)
            quantityPositiveElementInRow = 0;
        if (quantityPositiveElementInRow == columns)
            multiplyRowElementOfMatrix[i] = multiplyRowElement;
        else
            multiplyRowElementOfMatrix[i] = 0;
    }
    multiplyRowElement = 1;
    quantityPositiveElementInRow = 0;
}
for (int i = 0; i < rows; i++)
{
    if (multiplyRowElementOfMatrix[i] > 0)
        Console.WriteLine($"Multiply element row# {i} of matrix than haven't negative elements = {multiplyRowElementOfMatrix[i]}");
    else if (multiplyRowElementOfMatrix[i] < 0)
        quantityRowsWherePresentNegative++;
}
if (quantityRowsWherePresentNegative == rows)
    Console.WriteLine("In all rows of matrix presents one or more negative elements");