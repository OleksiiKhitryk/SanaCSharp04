using Matrix;
using System.Diagnostics.CodeAnalysis;

Console.WriteLine("Enter please the dimension of array[rows, columns]");
Console.Write("rows = ");
uint rows = uint.Parse(Console.ReadLine());
Console.Write("columns = ");
uint columns = uint.Parse(Console.ReadLine());
Console.WriteLine();

double[,] matrix = MatrixMethod.MatrixRandomDataFill(rows, columns);
MatrixMethod.WriteMatrixOnTerminal(matrix);
Console.WriteLine();

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
Console.WriteLine();

double maxValue = double.MinValue;                                  // максимальне із чисел, що зустрічається
int maxValueQuantity = 0;                                           // в заданій матриці більше одного разу
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        if (maxValue <= matrix[i, j])
            maxValue = matrix[i, j];
    }
}
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        if (maxValue == matrix[i, j])
            maxValueQuantity++;
    }
}
if (maxValueQuantity > 1)
{
    Console.WriteLine($"Max value in matrix = {maxValue}");
    Console.WriteLine($"Max value quantity in matrix  = {maxValueQuantity}");
}
else if (maxValueQuantity == 1)
    Console.WriteLine($"Max value = {maxValue} in matrix comes just one time");
Console.WriteLine();

int quantityNotNullElement, RowQuantityWithoutNullElements = 0;              //кількість рядків, які не містять жодного нульового елемента
for (int i = 0; i < rows; i++)
{
    quantityNotNullElement = 0;
    for (int j = 0; j < columns; j++)
        {
        if (matrix[i, j] != 0)
            quantityNotNullElement++;
    }
    if (quantityNotNullElement == columns)                           
        RowQuantityWithoutNullElements++;
}
if (RowQuantityWithoutNullElements > 0)                        
    Console.WriteLine($"Row quantity without null elements = {RowQuantityWithoutNullElements}");
else if (RowQuantityWithoutNullElements == 0)
    Console.WriteLine("In all rows present one or more null element");
Console.WriteLine();

int nullElements, ColumnQuantityWithNullElements = 0;                //кількість стовпців, які містять хоча б один нульовий елемент
 for (int j = 0; j < columns; j++)
{
    nullElements = 0;
    for (int i = 0; i < rows; i++)
    {
        if (matrix[i, j] == 0)                              
            nullElements++;
    }
    if (nullElements >= 1)
        ColumnQuantityWithNullElements++;
}
if (ColumnQuantityWithNullElements > 0)
    Console.WriteLine($"Column quantity with null elements = {ColumnQuantityWithNullElements}");
else if (ColumnQuantityWithNullElements == 0)
    Console.WriteLine("Column with null elemens are absent");
Console.WriteLine();

int equalElements, absentSeriesInRow = 0;                                  //номер рядка, в якому знаходиться найдовша 
for (int i = 0; i < rows; i++)                                             //серія однакових елементів
{
    equalElements = 0;
    for (int j = 0; j < columns - 1; j++)
    {
        if (matrix[i, j] == matrix[i, j + 1])
            equalElements++;
    }
    if (equalElements == 0)
        absentSeriesInRow++;
    else if (equalElements > 0)
        Console.WriteLine($"Row number #{i} have serial equal elements");
    else if (absentSeriesInRow == rows)
        Console.WriteLine("Row with serial equal elements are absent");
}
Console.WriteLine();

int quantityRowsWherePresentNegative = 0;                                 //добуток елементів в тих рядках, 
int quantityPositiveElementInRow;                                         //які не містять від’ємних елементів
double multiplyRowElement;                                      
double[] multiplyRowElementOfMatrix = new double[rows];
for (int i = 0; i < rows; i++)
{
    multiplyRowElement = 1;
    quantityPositiveElementInRow = 0;
    for (int j = 0; j < columns; j++)
    { 
        if (matrix[i, j] >= 0)
        {
            multiplyRowElement *= matrix[i, j];
            quantityPositiveElementInRow++;
        }
        if (quantityPositiveElementInRow == columns)
            multiplyRowElementOfMatrix[i] = multiplyRowElement;
        else
            multiplyRowElementOfMatrix[i] = -1;
    }
}
for (int j = 0; j < rows; j++)
{
    if (multiplyRowElementOfMatrix[j] >= 0)
        Console.WriteLine($"Multiply element row #{j} of matrix than haven't negative elements = {multiplyRowElementOfMatrix[j]}");
    else if (multiplyRowElementOfMatrix[j] < 0)
        quantityRowsWherePresentNegative++;
}
if (quantityRowsWherePresentNegative == rows)
    Console.WriteLine("In all rows of matrix presents one or more negative elements");
Console.WriteLine();

/* Absent yet */                                                    //максимум серед сум елементів діагоналей, паралельних головній діагоналі матриці


double sumElement;                                                   //суму елементів в тих стовпцях, які не містять від’ємних елементів
double[] sumColumnElementOfMatrix = new double[columns];
int notNegativeElements, quantityColumnsWithNegativeElements = 0;

for (int j = 0; j < columns; j++) 
{
    sumElement = 0;
    notNegativeElements = 0;
    for (int i = 0; i < rows; i++)
    {
        if (matrix[i, j] >= 0)
        {
            notNegativeElements++;
            sumElement += matrix[i, j];
        }
        if (notNegativeElements == rows)
            sumColumnElementOfMatrix[j] = sumElement;
        if (notNegativeElements < rows)
        {
            sumColumnElementOfMatrix[j] = -1;
            quantityColumnsWithNegativeElements++;
        }
    }
    if (sumColumnElementOfMatrix[j] > 0)
        Console.WriteLine($"Sum in column #{j} without negative elemens = {sumColumnElementOfMatrix[j]}");
}
if (quantityColumnsWithNegativeElements == columns)
    Console.WriteLine("All colums in matrix have negative element");
Console.WriteLine();