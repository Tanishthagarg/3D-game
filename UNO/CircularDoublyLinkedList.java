package Assignment1;

/*
 **Assignment 1
 **Tanishtha Garg
 **3111492
 **/

public class CircularDoublyLinkedList<E> {
    private static class Node<E>{
        private E element;
        private Node<E> next;
        private Node<E> prev;

        public Node(E e,Node<E>p, Node<E> n){
            element=e;
            prev=p;
            next=n;
        }

        public E getElement() {
            return element;
        }

        public Node<E> getPrev() {
            return prev;
        }

        public void setPrev(Node<E> prev) {
            this.prev = prev;
        }

        public Node<E> getNext() {
            return next;
        }

        public void setElement(E element) {
            this.element = element;
        }

        public void setNext(Node<E> next) {
            this.next = next;
        }
    }

 //   private Node<E> header=null;
   // private Node<E> tailer=null;
    private Node<E>tail=null;
    private int size=0;


    public CircularDoublyLinkedList(){
      //  header=new Node<>(null,null,null);
       // tailer=new Node<>(null,header,null);
        //header.setNext(tailer);
    }
    public int size(){return size;}
    public boolean isEmpty(){return size==0;}
    public E first(){
        if (isEmpty()) return null;
        return tail.getNext().getElement();
    }
    public E last(){
        if (isEmpty())return null;
        return tail.getElement();
    }
    private void addbetween(E e,Node<E> predecessor,Node<E> successor){
        Node<E> newest=new Node<>(e,predecessor,successor);
        predecessor.setNext(newest);
        successor.setPrev(newest);
        size++;
    }
    private E remove(Node<E> node){
        Node<E>predecessor=node.getPrev();
        Node<E>successor=node.getNext();
        predecessor.setNext(successor);
        successor.setPrev(predecessor);
        size--;
        return node.getElement();

    }
    public void addFirst(E e){
        if(size==0){
            tail=new Node<>(e,null,null);
            tail.setPrev(tail);
            tail.setNext(tail);
            size++;
        }
       /* if(size==1){
            Node<E> header=new Node<>(e,tail,null);
            tail.setPrev(header);
        } */
       else addbetween(e, tail,tail.getNext());
    }
    public void addLast(E e){
        addFirst(e);
        tail=tail.getNext();
       // addbetween(e,tailer.getPrev(),tailer);
    }
    public E removeFirst(){
        if(isEmpty())return null;
       // if(tail.getNext()==tail.getPrev()) tail=null;
        return remove(tail.getNext());
    }
    public E removeLast(){
        if (isEmpty())return null;
       // if(tail.getNext()==tail.getPrev()) tail=null;

        E answer= remove(tail);
        tail=tail.getPrev();
        return answer;

    }
    public void rotateForward(){
        if(tail!=null) tail=tail.getNext();
    }
    public void rotateReverse(){
        if(tail!=null) tail=tail.getPrev();
    }

    @Override
    public String toString() {
        return "CircularDoublyLinkedList{" +
                "tail=" + tail.getElement() +
                ", size=" + size +
                '}';
    }
}
