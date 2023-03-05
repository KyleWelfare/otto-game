using System.ComponentModel;

public enum EBattleStates
{
    [Description("intro")]
    Intro,
    [Description("actionSelect")]
    ActionSelect,
    [Description("playerAttack")]
    PlayerAttack,
    [Description("enemyAttack")]
    EnemyAttack
}

public static class EnumExtensionMethods
{
    public static string GetEnumDescription(this EBattleStates enumValue)
    {
        var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
        var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
        return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
    }
}