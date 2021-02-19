using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows;


namespace WpfApp1
{
    public class FOAButton
    {
        gr691_baoEntities1 db = new gr691_baoEntities1();
        FieldOfActivity FieldOfActivity = new FieldOfActivity();
        public bool Insert(string id, string Fieldofact)
        {
            Regex SpecialSimbols = new Regex("([#]|[=]|[/]|[*]|[@]|[&]|[>]|[<]|[;]|[']|[$]|[№]|[!]|[№]|[;]|[{]|[}]|[[]|[]]|[~])");
            Regex searchFullNumber = new Regex(@"(\d)");
            Regex Words = new Regex("^[A-za-z]");
            MatchCollection matchSpecialSymbol;
            MatchCollection matchSearchFullNumber;
            MatchCollection matchWords;
            matchSpecialSymbol = SpecialSimbols.Matches(Fieldofact);
            matchSearchFullNumber = searchFullNumber.Matches(Fieldofact);
            matchWords = Words.Matches(Fieldofact);
            try
            {
                if (string.IsNullOrWhiteSpace(id) == false)
                {
                    MessageBox.Show("Ошибка в таблице <FieldOfActivity>!\nВы хотели добавить id сами. Он проставляется автоматически.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(Fieldofact) == true)
                {
                    MessageBox.Show("Ошибка в таблице <FieldOfActivity>!\nВы забыли внести данные в поле <name>.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (matchSpecialSymbol.Count > 0)
                {
                    MessageBox.Show("Ошибка в таблице <FieldOfActivity>!\nВ названии предмета не допускаются спецсимволы.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (matchSearchFullNumber.Count > 0)
                {
                    MessageBox.Show("Ошибка в таблице <FieldOfActivity>!\nВ названии предмета не допускаются цифры или числа.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (matchWords.Count > 0)
                {
                    MessageBox.Show("Ошибка в таблице <FieldOfActivity>!\nВ названии предмета вводятся только кирилица.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    FieldOfActivity.FieldOfActivity1 = Fieldofact;
                    db.FieldOfActivity.Add(FieldOfActivity);
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("ЖОПАОшибка в таблице <FieldOfActivity>!\nВведите корректные значения.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public bool Delete(string id)
        {
            try
            {
                int num = Convert.ToInt32(id);
                var dRow = db.FieldOfActivity.Where(w => w.Id == num).FirstOrDefault();
                if (dRow == null)
                {
                    MessageBox.Show("Ошибка в таблице <FieldOfActivity>!\nТакого id не существует.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    try
                    {
                        db.FieldOfActivity.Remove(dRow);
                        db.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка в таблице <FieldOfActivity>!\nДанный id связан с таблицей <Teacher_predmet>, поэтому удалите его из неё.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка в таблице <FieldOfActivity>!\nВы написали в id не цифру/число.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        } 
        public bool Update(string id, string Fieldofact)
        {
            try
            {
                Regex SpecialSimbols = new Regex("([#]|[=]|[/]|[*]|[@]|[&]|[>]|[<]|[;]|[']|[$]|[№]|[!]|[№]|[;]|[{]|[}]|[[]|[]]|[~])");
                Regex searchFullNumber = new Regex(@"(\d)");
                Regex Words = new Regex("^[A-za-z]");
                MatchCollection matchSpecialSymbol;
                MatchCollection matchSearchFullNumber;
                MatchCollection matchWords;
                matchSpecialSymbol = SpecialSimbols.Matches(Fieldofact);
                matchSearchFullNumber = searchFullNumber.Matches(Fieldofact);
                matchWords = Words.Matches(Fieldofact);

                int num = Convert.ToInt32(id);
                var uRow = db.FieldOfActivity.Where(w => w.Id == num).FirstOrDefault();
                if (string.IsNullOrWhiteSpace(Fieldofact) == true)
                {
                    MessageBox.Show("Ошибка в таблице <FieldOfActivity>!\nВы забыли внести данные в поле <name>.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (matchSpecialSymbol.Count > 0)
                {
                    MessageBox.Show("Ошибка в таблице <FieldOfActivity>!\nВ названии предмета не допускаются спецсимволы.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (matchSearchFullNumber.Count > 0)
                {
                    MessageBox.Show("Ошибка в таблице <FieldOfActivity>!\nВ названии предмета не допускаются цифры или числа.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (matchWords.Count > 0)
                {
                    MessageBox.Show("Ошибка в таблице <FieldOfActivity>!\nВ названии предмета вводятся только кирилица.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (uRow == null)
                {
                    MessageBox.Show("Ошибка в таблице <FieldOfActivity>!\nВведите id, который уже есть в таблице.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                uRow.FieldOfActivity1 = Fieldofact;
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Ошибка в таблице <FieldOfActivity>!\nВведите корректные значения.", "My App", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
