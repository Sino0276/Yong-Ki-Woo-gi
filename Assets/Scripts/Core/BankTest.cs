using System;
using UnityEngine;

public class BankTest : MonoBehaviour
{
    private UserAccount userAccount;
    private int userAccountId;

    private void Start()
    {
        var personalInformation = new PersonalInformation(){name = "John", birthDate = new DateTime(1990, 1, 1), gender = Gender.Male};
        userAccountId = PiggyBank.Instance.CreateUserAccount(personalInformation);
        userAccount = PiggyBank.Instance.GetUserAccount(userAccountId);
    }

    [ContextMenu("PrintUserAccountInfo")]
    public void PrintUserAccountInfo()
    {
        Debug.Log($"UserAccountId: {userAccountId}");
        Debug.Log($"UserAccountName: {userAccount.PersonalInformation.name}");
        Debug.Log($"UserAccountBirthDate: {userAccount.PersonalInformation.birthDate}");
        Debug.Log($"UserAccountGender: {userAccount.PersonalInformation.gender}");
    }

    [ContextMenu("PrintAccountInfo")]
    public void PrintAccountInfo()
    {
        foreach (var account in userAccount.Accounts)
        {
            Debug.Log($"AccountId: {account.Key}");
            Debug.Log($"AccountMoney: {account.Value.Money}");
            Debug.Log($"AccountDepositRule: {account.Value.DepositRule}");
        }
    }

    [ContextMenu("PrintCardInfo")]
    public void PrintCardInfo()
    {
        foreach (var card in userAccount.Cards)
        {
            Debug.Log($"CardId: {card.Key}");
            Debug.Log($"CardDepositRule: {card.Value.DepositRule}");
            Debug.Log($"CardPaymentDate: {card.Value.PaymentDate}");
        }
    }

    public void CreateAccount()
    {
        userAccount.CreateAccount();
    }

    public void RemoveAccount(int id)
    {
        userAccount.RemoveAccount(id);
    }

    public void CreateCard(int paymentDate)
    {
        userAccount.CreateCard(paymentDate);
    }

    public void RemoveCard(int id)
    {
        userAccount.RemoveCard(id);
    }
}