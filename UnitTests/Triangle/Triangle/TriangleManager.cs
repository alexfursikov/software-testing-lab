namespace Triangle
{
    public class TriangleManager
    {
        public static bool IsExist(float a, float b, float c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                return false;
            else if (a + b <= c || a + c <= b || b + c <= a)
                return false;
            else
                return true; 
        }
    }
}
