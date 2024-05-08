using System.ServiceModel;

[ServiceContract]
public interface ICalculadoraService
{
    [OperationContract]
    int Sumar(int num1, int num2);
}
