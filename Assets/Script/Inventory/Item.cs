using System;
using System.Collections.Generic;
using System.Text;

public class Stat : IComparer<Stat>
{
    public float maxhp, atk, mvspd, atkrng, atkspd, beauty, pow, def;

    public Stat(){ }
    public Stat(float maxhp, float beauty, float pow, float atk, float mvspd, float atkrng, float atkspd, float def)
    {
        this.maxhp = maxhp;
        this.atk = atk;
        this.mvspd = mvspd;
        this.atkrng = atkrng;
        this.atkspd = atkspd;
        this.beauty = beauty;
        this.pow = pow;
        this.def = def;
    }
    public Stat(Stat s)
    {
        this.maxhp = s.maxhp;
        this.atk = s.atk;
        this.mvspd = s.mvspd;
        this.atkrng = s.atkrng;
        this.atkspd = s.atkspd;
        this.beauty = s.beauty;
        this.pow = s.pow;
        this.def = s.def;
    }

    static public Stat operator +(Stat a, Stat b)
    {
        return new Stat(
                a.maxhp + b.maxhp,
                a.beauty + b.beauty,
                a.pow + b.pow,
                a.atk + b.atk,
                a.mvspd + b.mvspd,
                a.atkrng + b.atkrng,
                a.atkspd + b.atkspd,
                a.def + b.def
            );
    }
    static public Stat operator -(Stat a, Stat b)
    {
        return new Stat(
                a.maxhp - b.maxhp,
                a.beauty - b.beauty,
                a.pow - b.pow,
                a.atk - b.atk,
                a.mvspd - b.mvspd,
                a.atkrng - b.atkrng,
                a.atkspd - b.atkspd,
                a.def - b.def
            );
    }
    public override string ToString()
    {
        return ToString(false);
    }

    public string ToString(bool showall)
    {
        StringBuilder sb = new StringBuilder();

        if (showall || maxhp != 0) sb.AppendFormat("최대 체력: {0:0.0#}\n", maxhp);
        if (showall || atk != 0) sb.AppendFormat("공격력 : {0:0.0#}\n", atk);
        if (showall || mvspd != 0) sb.AppendFormat("이동속도: {0:0.0#}\n", mvspd);
        if (showall || atkrng != 0) sb.AppendFormat("사거리: {0:0.0#}\n", atkrng);
        if (showall || atkspd != 0) sb.AppendFormat("공격 속도: {0:0.0#}\n", atkspd);

        if (beauty > 0) sb.AppendFormat("아름다움: {0:0.0#}\n", beauty);
        else if (beauty < 0) sb.AppendFormat("기괴함: {0:0.0#}\n", -beauty);
        else if (showall) sb.AppendFormat("아름다움: {0:0.0#}\n", beauty);

        if (showall || pow != 0) sb.AppendFormat("힘: {0:0.0#}", pow);
        if (showall || def != 0) sb.AppendFormat("방어력: {0:0.0#}", def);


        return sb.ToString();
    }

    int IComparer<Stat>.Compare(Stat x, Stat y)
    {
        Stat tmp = x - y;
        if (tmp.maxhp < 0) return -1;
        else if (tmp.maxhp > 0) return 1;

        if (tmp.atk < 0) return -1;
        else if (tmp.atk > 0) return 1;

        if (tmp.mvspd < 0) return -1;
        else if (tmp.mvspd > 0) return 1;

        if (tmp.atkrng < 0) return -1;
        else if (tmp.atkrng > 0) return 1;

        if (tmp.atkspd < 0) return -1;
        else if (tmp.atkspd > 0) return 1;

        if (tmp.beauty < 0) return -1;
        else if (tmp.beauty > 0) return 1;

        if (tmp.pow < 0) return -1;
        else if (tmp.pow > 0) return 1;

        if (tmp.def < 0) return -1;
        else if (tmp.atkspd > 0) return 1;

        return 0;
    }
    bool IsGreaterThen(Stat a)
    {
        Stat cmp = this - a;
        if (cmp.maxhp <= 0) return false;
        if (cmp.atk <= 0) return false;
        if (cmp.mvspd <= 0) return false;
        if (cmp.atkrng <= 0) return false;
        if (cmp.atkspd <= 0) return false;

        if (cmp.beauty != 0)
        {
            if (this.beauty < 0 && a.beauty > 0) return false;
            if (this.beauty > 0 && a.beauty < 0) return false;
            if (Math.Abs(this.beauty) < Math.Abs(a.beauty)) return false;
        }


        if (cmp.pow < 0) return false;

        if (cmp.def < 0) return false;

        return true;
    }
}
public class Item : IComparer<Item>
{
    public enum Rairity
    {
        normal = 0,
        uncommon,
        rare,
        epic,
        unique,
        legendary
    }
    public enum ItemType
    {
        none,
        head, body, arm, leg, heart, weapon
    }
    public enum CompareMode
    {
        name, rarity
    }
    public static CompareMode compareMode;

    public Rairity rairity;
    public string codeName;
    public string nameText;
    public string tooltipText { get { return stat.ToString(); } }
    public string flavorText;
    public ItemType type;
    public Stat stat;

    public Item(Rairity rairity, string codename, string nameText, string flavorText, ItemType type, Stat stat)
    {
        this.rairity = rairity;
        this.codeName = codename;
        this.nameText = nameText;
        this.flavorText = flavorText;
        this.type = type;
        this.stat = new Stat(stat);
    }
    public Item(Item ie)
    {
        this.rairity = ie.rairity;
        this.codeName = ie.codeName;
        this.nameText = ie.nameText;
        this.flavorText = ie.flavorText;
        this.type = ie.type;
        this.stat = new Stat(ie.stat);
    }
    public int Compare(Item x, Item y)
    {
        throw new NotImplementedException("아이템 소팅 비교");
        //return x - y;
    }
}
