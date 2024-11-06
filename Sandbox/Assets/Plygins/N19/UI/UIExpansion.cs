namespace N19
{
    public static class UIExpansion
    {
        public static float FillAmout(this UnityEngine.UI.Image image, object currentValue, object maxValue)
        {
            return image.fillAmount = UMath.Percent(currentValue, maxValue);
        }

        public static float FillAmout(this UnityEngine.UI.Slider image, object currentValue, object maxValue)
        {
            return image.value = UMath.Percent(currentValue, maxValue);
        }
    }
} 