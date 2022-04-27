package Assignment1;

/*
 **Assignment 1
 **Tanishtha Garg
 **3111492
 **/

public enum Colour {
    BLUE(1), RED(2), GREEN(3) ,YELLOW(4),BLACK(5);
    private int val;

    private Colour(int v)
    {val=v;}
    public int getvalue(){
        return val;
    }

    public void setVal(int val) {
        this.val = val;
    }
}
