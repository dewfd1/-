#include <iostream>

using namespace std;

struct Info
{
	int accountNumber;
	double balance;
	double intrestRate;

	Info(int accountNumber, double balance, double intrestRate)
	{
		this->accountNumber = accountNumber;
		this->balance = 0;
		this->intrestRate = 0;
	}
};

class BankAccount {

private:
	int accountNumber;
	double balance;
	double interestRate;

public:

	void deposit();
	void withdraw();
	void getBalance();
	void getInterestRate();
	void setInterestRare();
	void getAccountNumber();

	BankAccount(int accountNumber, double bakance, double InterestRate)
	{
		this->accountNumber = accountNumber;
		this->balance = 0;
		this->interestRate = 0;
	}
	friend bool transfer(BankAccount& from, BankAccount& to, double amount);
};

void BankAccount::deposit()
{
	cout << "Введите номер счета: ";
	cin >> this->accountNumber;
	cout << "Внесите деньги: ";
	cin >> this->balance;
	cout << "Счет открыт" << endl << endl;
}

void BankAccount::getBalance()
{
	cout << endl << "Текущее состояние счета: " << endl;
	cout << "Номер счета: " << this->accountNumber << endl;
	cout << "Количество средств на счете: " << this->balance << endl;
}

void BankAccount::withdraw()
{
	long long int a;

	do
	{
		cout << "Сколько желаете снять? ";
		cin >> a;
		if (a > this->balance) cout << "Недостаточно средств на счете" << endl;
	} while (a > this->balance);
	this->balance -= a;
	cout << "Деньги успешно сняты" << endl;
}

void BankAccount::getInterestRate()
{
	double monthlyInterestRate = 1.0 / 12;
	cout << "Введите по какой ставке хотите положить деньги ";
	cin >> this->interestRate;
	double interestEarned = this->balance * this->interestRate * monthlyInterestRate;
	cout << "Теперь вы будете получать в год: " << interestEarned << endl;
}

void BankAccount::setInterestRare()
{
	double a = 1.0 / 12;
	int b = 5;
	this->interestRate = this->balance * b * a;
	cout << "Процентная ставка обновлена до 5 и теперь вы будете получать: " << this->interestRate << endl;
}

void BankAccount::getAccountNumber()
{
	cout << "Номер вашей банковской карты: " << this->accountNumber << endl;
}

bool transfer(BankAccount& from, BankAccount& to, double amount) {
	if (amount <= from.balance)
	{
		from.balance -= amount;
		to.balance += amount;
		std::cout << "Перевод " << amount << " со счета " << from.accountNumber << " на счет " << to.accountNumber << " успешно " << std::endl;
		return true;
	}
	else
	{
		std::cerr << "Ошибка " << std::endl;
		return false;
	}
}

int main()
{
	setlocale(LC_ALL, "Russian");

	BankAccount account1(1, 0, 0);
	BankAccount account2(2, 0, 0);

	account1.deposit();
	account1.withdraw();
	account1.getBalance();
	account1.getInterestRate();
	account1.setInterestRare();
	account1.getAccountNumber();

}
