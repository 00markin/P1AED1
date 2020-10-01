using System;
using System.IO;

public class Gasto{
  public float saldoA, saldoN, price;
  public string tag;

  public void gravarGasto(Gasto gast){
    if(File.Exists("Gastos.txt")){
      StreamWriter escrita = File.AppendText("Gastos.txt");
      escrita.WriteLine(gast.price);
      escrita.WriteLine(gast.tag);
      escrita.Close();
    }
    else {
      StreamWriter escrita = new StreamWriter("Gastos.txt");
      escrita.WriteLine(gast.price);
      escrita.WriteLine(gast.tag);
      escrita.Close();
    }
  }
  public void attSaldo(Carteira cart, Gasto gast){
    string[] carteiraE = File.ReadAllLines("Carteira.txt");
    cart.saldo = float.Parse(carteiraE[0]);
    cart.saldo = gast.saldoN;
    cart.gravarC(cart);
  }

  public void registrarGasto(Carteira cart){
    int op = 0;
    Gasto gast = new Gasto();
    gast.saldoA = cart.saldo;
    do{
      Console.Clear();
      Console.WriteLine ("De quanto foi seu gasto?");
      gast.price =float.Parse(Console.ReadLine());
      Console.WriteLine ("Dê um nome(tag) para seu gasto.");
      gast.tag = Console.ReadLine();
      gast.saldoN = gast.saldoA - gast.price;
      gravarGasto(gast);
      attSaldo(cart,gast);
      Console.Clear();
      Console.WriteLine ("Gasto registrado com sucesso.");
      Console.WriteLine ("Deseja registrar outro gasto?");
      Console.WriteLine ("1 - Para 'SIM', 2 - para 'NÃO'");
      op = int.Parse(Console.ReadLine());
      if((op < 1)||(op > 2)){
        Console.WriteLine ("Opção inválida");
      }
    }while (op !=2);
    Console.Clear();
  }
}