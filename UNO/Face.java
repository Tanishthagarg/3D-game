package Assignment1;

/*
 **Assignment 1
 **Tanishtha Garg
 **3111492
 **/
public enum Face {
   ZERO(0), ONE(1), TWO(2), THREE(3), FOUR(4), FIVE(5), SIX(6), SEVEN(7), EIGHT(8), NINE(9) ,SKIP(10) ,REVERSE(11) ,WILD(12), NotACard(13);
    private int val;

    private Face(int v)
    {val=v;}
    public int getvalue(){
        return val;
    }
}
