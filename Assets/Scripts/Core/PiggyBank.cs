using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PiggyBank : Singleton<PiggyBank>
{
    private Dictionary<int, UserAccount> userAccounts = new Dictionary<int, UserAccount>();
    public IReadOnlyDictionary<int, UserAccount> UserAccounts => userAccounts;

    private int nextId = 0;
    private HashSet<int> remedicalId = new HashSet<int>();

    public int CreateUserAccount(PersonalInformation personalInformation)
    {   
        int id = 0;

        if (remedicalId.Count > 0)
        {
            id = remedicalId.First();
            remedicalId.Remove(id);
        }
        else id = nextId++;

        var userAccount = new UserAccount(id, personalInformation, 1000);
        userAccounts.Add(id, userAccount);

        return id;
    }

    public void RemoveUserAccount(int id)
    {
        if (!userAccounts.ContainsKey(id)) return;
        userAccounts.Remove(id);
        remedicalId.Add(id);
    }

    public UserAccount GetUserAccount(int id)
    {
        if (!userAccounts.ContainsKey(id)) return null;
        return userAccounts[id];
    }
}

public class UserAccount
{
    private int accountId;
    public int AccountId => accountId;

    private PersonalInformation personalInformation;
    public PersonalInformation PersonalInformation => personalInformation;

    private int creditRating;
    public int CreditRating => creditRating;

    private Dictionary<int, Account> accounts = new Dictionary<int, Account>();
    public IReadOnlyDictionary<int, Account> Accounts => accounts;
    private int nextAccountId = 0;
    private HashSet<int> remedicalAccountId = new HashSet<int>();

    private Dictionary<int, Card> cards = new Dictionary<int, Card>();
    public IReadOnlyDictionary<int, Card> Cards => cards;
    private int nextCardId = 0;
    private HashSet<int> remedicalCardId = new HashSet<int>();

    public UserAccount(int accountId, PersonalInformation personalInformation, int creditRating)
    {
        this.accountId = accountId;
        this.personalInformation = personalInformation;
        this.creditRating = creditRating;
    }

    public int CreateAccount()
    {
        int id = 0;

        if (remedicalAccountId.Count > 0)
        {
            id = remedicalAccountId.First();
            remedicalAccountId.Remove(id);
        }
        else id = nextAccountId++;

        var account = new Account(id, 100);
        accounts.Add(id, account);

        return id;
    }

    public void RemoveAccount(int id)
    {
        if (!accounts.ContainsKey(id)) return;
        accounts.Remove(id);
        remedicalAccountId.Add(id);
    }
    
    public Account GetAccount(int id)
    {
        if (!accounts.ContainsKey(id)) return null;
        return accounts[id];
    }

    public int CreateCard(int paymentDate)
    {
        int id = 0;
        if (remedicalCardId.Count > 0)
        {
            id = remedicalCardId.First();
            remedicalCardId.Remove(id);
        }
        else id = nextCardId++;

        var card = new Card(id, 100, paymentDate);
        cards.Add(id, card);
        
        return id;
    }

    public void RemoveCard(int id)
    {
        if (!cards.ContainsKey(id)) return;
        cards.Remove(id);
        remedicalCardId.Add(id);
    }
    
    public Card GetCard(int id)
    {
        if (!cards.ContainsKey(id)) return null;
        return cards[id];
    }
}

public class Account
{
    private int accountId;
    public int AccountId => accountId;
    private int depositRule;
    public int DepositRule => depositRule;
    private int money;
    public int Money => money;

    public Account(int accountId, int depositRule)
    {
        this.accountId = accountId;
        this.depositRule = depositRule;
        this.money = 0;
    }
}

public class Card
{
    private int cardId;
    public int CardId => cardId;
    private int depositRule;
    public int DepositRule => depositRule;
    private int paymentDate;
    public int PaymentDate => paymentDate;

    public Card(int cardId, int depositRule, int paymentDate)
    {
        this.cardId = cardId;
        this.depositRule = depositRule;
        this.paymentDate = paymentDate;
    }
}

public struct PersonalInformation
{
    public string name;
    public DateTime birthDate;
    public Gender gender;
}

public enum Gender
{
    Male,
    Female,
}