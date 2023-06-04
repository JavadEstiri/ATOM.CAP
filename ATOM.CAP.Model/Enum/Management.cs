
namespace ATOM.CAP.Model
{
    public enum UserType : int
    {
        نامشخص = 0,
        مدیر = 1,
        توسعه_دهنده = 2,
        کاربر = 3
    }

    public enum UserStatusType : int
    {
        نامشخص = 0,
        فعال = 1,
        غیرفعال = 2,
        حذف_شده = 3
    }

    public enum TransactionType : int
    {
        نامشخص = 0,
        واریز_به_کیف_پول = 1,
        برداشت_از_کیف_پول = 2
    }

    public enum TransactionSubjectType : int
    {
        نامشخص = 0,
        شارژ_کیف_پول = 1,
        برداشت_از_کیف_پول = 2,
        خرید_محصول = 3,
    }

    public enum TransactionStatusType : int
    {
        نامشخص = 0,
        ثبت_درخواست = 1,
        در_حال_انجام = 2,
        موفقیت_آمیز = 100,
        ناموفق = 200
    }
}
