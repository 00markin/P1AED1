using System;
using System.IO;

public class Carteira{
  public float saldo, salario;
  public int payday;
  public bool exist = false;

  public void gravarC(Carteira cart){
    StreamWriter escrita = new StreamWriter("Carteira.txt");
    escrita.WriteLine(cart.saldo);
    escrita.WriteLine(cart.salario);
    escrita.WriteLine(cart.payday);
    escrita.WriteLine(cart.exist);
    escrita.Close();
  }

  public Carteira lerC(Carteira cart){
    string[] carteiraE = File.ReadAllLines("Carteira.txt");
    cart.saldo = float.Parse(carteiraE[0]);
    cart.salario = float.Parse(carteiraE[1]);
    cart.payday = int.Parse(carteiraE[2]);
    cart.exist = bool.Parse(carteiraE[3]);
    return cart;
  }

  public Carteira registrarC(Carteira cart){
    if(cart.exist == true){
      while(true){
        Console.WriteLine("Carteira já existente, deseja apagar e criar uma nova?");
        Console.WriteLine("1 - 'SIM' 2 - 'NÃO'");
        int opnew = int.Parse(Console.ReadLine());
        if((opnew == 1)||(opnew == 2)){
          if(opnew == 1){
            Console.WriteLine("Qual seu saldo atual na carteira?");
            cart.saldo = float.Parse(Console.ReadLine());
            Console.WriteLine("Quanto você recebe de salário?");
            cart.salario = float.Parse(Console.ReadLine());
            Console.WriteLine("Qual seu dia de receber o salário?");
            Console.WriteLine("Digite apenas o número do dia.");
            cart.payday = int.Parse(Console.ReadLine());
            cart.exist = true;
            gravarC(cart);
            Console.Clear();
            return cart;
          }
          if(opnew == 2){
            Console.Clear();
            return cart;
          }
        }
        else {
          Console.Clear();
          Console.WriteLine("Opção inválida");
        }
      }
    }
    else
    {
      Console.Clear();
      Console.WriteLine("Qual seu saldo atual na carteira?");
      cart.saldo = float.Parse(Console.ReadLine());
      Console.WriteLine("Quanto você recebe de salário?");
      cart.salario = float.Parse(Console.ReadLine());
      Console.WriteLine("Qual seu dia de receber o salário?");
      Console.WriteLine("Digite apenas o número do dia.");
      cart.payday = int.Parse(Console.ReadLine());
      cart.exist = true;
      gravarC(cart);
      return cart;
    }
  }

  public Carteira menuCart(Carteira cart){
    int opcart = 0;
    if(File.Exists("Carteira.txt")){
      cart = lerC(cart);
    }
    while(opcart!= 5){
      Console.WriteLine ("------------------------------");
      Console.WriteLine ("1 - REGISTRAR NOVA CARTEIRA");
      Console.WriteLine ("2 - CONSULTAR CARTEIRA");
      Console.WriteLine ("3 - REGISTRAR SALÁRIO");
      Console.WriteLine ("4 - REGISTRAR DIA DE PAGAMENTO");
      Console.WriteLine ("5 - SAIR");
      Console.WriteLine ("------------------------------");
      opcart = int.Parse(Console.ReadLine());
      switch(opcart){
        case 1:
        Console.Clear();
        cart = registrarC(cart);
        break;
        case 2:
        Console.Clear();
        Console.WriteLine("Saldo em carteira: " + cart.saldo);
        break;
        case 3:
        Console.Clear();
        Console.WriteLine("Quanto você recebe de salário?");
        cart.salario = float.Parse(Console.ReadLine());
        gravarC(cart);
        break;
        case 4:
        Console.Clear();
        Console.WriteLine("Qual seu dia de receber o salário?");
        Console.WriteLine("Digite apenas o número do dia.");
        cart.payday = int.Parse(Console.ReadLine());;
        gravarC(cart);
        break;
        case 5:
        Console.Clear();
        break;
        default:
        Console.Clear();
        Console.WriteLine("Opção inválida, tente novamente:");
        break;
      }
    }
    return cart;
  }
}