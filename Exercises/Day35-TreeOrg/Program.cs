using System;
using System.Collections.Generic;

public class EmployeeNode
{
    public string Name { get; set; }
    public string Position { get; set; }
    public List<EmployeeNode> Reports { get; set; }

    public EmployeeNode(string name, string position)
    {
        Name = name;
        Position = position;
        Reports = new List<EmployeeNode>();
    }

    public void AddReport(EmployeeNode employee)
    {
        Reports.Add(employee);
    }
}

public class OrganizationTree
{
    public EmployeeNode Root { get; private set; }

    public OrganizationTree(EmployeeNode root)
    {
        Root = root;
    }

    public void DisplayFullHierarchy()
    {
        PrintRecursive(Root, 0);
    }

    private void PrintRecursive(EmployeeNode current, int level)
    {
        string indent = new string('-', level * 4);
        Console.WriteLine($"{indent}{current.Name} ({current.Position})");

        foreach (var emp in current.Reports)
        {
            PrintRecursive(emp, level + 1);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var ceo = new EmployeeNode("Aman", "CEO");
        var cto = new EmployeeNode("Suresh", "CTO");
        var manager = new EmployeeNode("Sonia", "Dev Manager");
        var dev1 = new EmployeeNode("Sara", "Senior Dev");
        var dev2 = new EmployeeNode("Divakar", "Junior Dev");
        var cfo = new EmployeeNode("Rajesh", "CFO");
        var accOfficer = new EmployeeNode("Rajat", "Account Officer");

        var company = new OrganizationTree(ceo);

        ceo.AddReport(cto);
        ceo.AddReport(cfo);

        cto.AddReport(manager);
        manager.AddReport(dev1);
        manager.AddReport(dev2);

        cfo.AddReport(accOfficer);

        company.DisplayFullHierarchy();
    }
}