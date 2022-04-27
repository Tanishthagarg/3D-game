package Assignment1;

/*
**Assignment 1
**Tanishtha Garg
**3111492
**/

public class SingularlyLinkedList<E> {
        private static class Node<E>{
            private E element;
            private Node<E> next;

            public Node(E e, Node<E> n){
                element=e;
                next=n;
            }

            public E getElement() {
                return element;
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

        private Node<E> head=null;
        private Node<E> tail=null;
        private int size=0;

        public SingularlyLinkedList(){ }

        public int size(){return size;}
        public boolean isEmpty() {return size==0;}

        public E first(){
            if (isEmpty()) return null;
            return head.getElement();
        }
        public void addFirst(E e){
            head=new Node<>(e,head);
            if(size==0)
                tail=head;
            size++;
        }
        public void addLast(E e){
            Node<E>newest=new Node<>(e,null);
            if(isEmpty())
                head=newest;
            else
                tail.setNext(newest);
            tail=newest;
            size++;
        }
        public E removeFirst(){
            if(isEmpty())return null;
            E ans=head.getElement();
            head=head.getNext();
            size--;
            if (size==0)
                tail=null;
            return ans;
        }


        @Override
        public String toString() {

            StringBuilder sb=new StringBuilder("[");
            while(head!=tail){
                sb.append(head.getElement()+", ");
                head=head.getNext();

            }
            sb.append(tail.getElement()+"]");

            return sb.toString();
        }
    }


