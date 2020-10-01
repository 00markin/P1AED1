using System;
using System.IO;

class MainClass {
  public static void Main (string[] args) {
    int op = 0;
    Carteira cart = new Carteira();
    Gasto gast = new Gasto();
    Conta cont = new Conta();
    Relatorio relat = new Relatorio();
    if(File.Exists("Carteira.txt")){
      cart = cart.lerC(cart);
    }
    Console.WriteLine ("Bem vindo ao seu PocketGuide!");
    Console.WriteLine ("Selecione a opção desejada escrevendo apenas o número:");
    while(op!= 5){
      Console.WriteLine ("------------------------------");
      Console.WriteLine ("1 - CONSULTAR CARTEIRA");
      Console.WriteLine ("2 - REGISTRAR GASTOS DE HOJE");
      Console.WriteLine ("3 - CONTAS A PAGAR");
      Console.WriteLine ("4 - RELATÓRIO FINANCEIRO");
      Console.WriteLine ("5 - SAIR");
      Console.WriteLine ("------------------------------");
      op = int.Parse(Console.ReadLine());
      switch(op){
        case 1:
        Console.Clear();
        cart = cart.menuCart(cart);
        break;
        case 2:
        Console.Clear();
        if(cart.exist == false){
          Console.WriteLine("Carteira inexistente, Registraremos uma agora");
          cart = cart.registrarC(cart);
        }
        else {
          gast.registrarGasto(cart);
        }
        break;
        case 3:
        Console.Clear();
        cont.menuConta(cont);
        break;
        case 4:
        Console.Clear();
        relat.menuRelat(cart);
        break;
        case 5:
        Console.Clear();
        Console.WriteLine("Obrigado por utilizar o PocketGuide!");
        Console.ReadKey();
        break;
        default:
        Console.Clear();
        Console.WriteLine("Opção inválida, tente novamente:");
        break;
      }
    }
  }
}