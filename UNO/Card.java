package Assignment1;

/*
 **Assignment 1
 **Tanishtha Garg
 **3111492
 **/

/**
 * Card Class: Class that creates a card using enum Colour and Face
 * @author Tanishtha Garg
 *
 */
public class Card {
    public Colour colour;
    public Face face;

    /**
     * Constructor for Card
     * @param colour colour of the card
     * @param face face of the card
     */
    public Card(Colour colour,Face face){
        this.colour=colour;
        this.face=face;
    }

    /**
     * Returns the Colour of the card
     * @return colour
     */
    public Colour getColour() {
        return colour;
    }

    /**
     * Returns the Face of the card
     * @return Face
     */
    public Face getFace() {
        return face;
    }

    /**
     * Sets the Colour of the card
     * @param colour color that is being set
     */
    public void setColour(Colour colour) {
        this.colour = colour;
    }

    /**
     * Sets the Face of the card
     * @param face face that is being set
     */
    public void setFace(Face face) {
        this.face = face;
    }

    /**
     * Override the toString() to display the resulting Card in a specific way
     * @return String that will be displayed
     */
    @Override
    public String toString() {
        StringBuilder sb=new StringBuilder();
        if(face.getvalue()==10) sb.append(colour+"\u2205") ;
        else if(face.getvalue()==11) sb.append(colour+"\u21c4");
        else if(face.getvalue()==12) sb.append(face+"*");
        else sb.append(colour+" "+face.getvalue());
        return sb.toString();
    }
}
