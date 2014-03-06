package stdlib;

/**
 * Draw listener
 * Created by beginor on 13-11-26.
 */
public interface DrawListener {
    public void mousePressed (double x, double y);
    public void mouseDragged (double x, double y);
    public void mouseReleased(double x, double y);
    public void keyTyped(char c);
}
