import java.awt.*;
import javax.swing.*;
import javax.swing.border.LineBorder;

public class CustomButton {
    public static JButton Button(String text, int x, int y, int width, int height) {
        JButton button = new JButton(text);
        button.setBounds(x, y, width, height);
        button.setBackground(Color.WHITE);
        button.setFont(new Font("Microsoft Sans Serif", Font.PLAIN, 12));
        button.setBorder(new LineBorder(Color.BLACK, 2));
        button.setFocusPainted(false);
        button.setContentAreaFilled(false);
        button.setOpaque(true);
        
        return button;
    }
}