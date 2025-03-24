import java.awt.*;
import javax.swing.*;
import javax.swing.border.LineBorder;
import javax.swing.plaf.basic.BasicScrollBarUI;

public class CreateLayout {
    public static void main(String[] args) {
        JFrame frame = new JFrame();
        frame.setTitle("Auto Typer By Duncan Jones");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setResizable(false);
        frame.setSize(530, 325);
        frame.getContentPane().setBackground(Color.lightGray);
        frame.setLayout(null);
        frame.getContentPane().setBackground(new Color(240, 240, 240));


        // Hotkey1Text:
        JLabel Hotkey1Text = new JLabel("Start/Pause:", SwingConstants.RIGHT);
        Hotkey1Text.setFont(new Font("Microsoft Sans Serif", Font.PLAIN, 16));
        Hotkey1Text.setBounds(25, -22 , 100, 100); 
        frame.add(Hotkey1Text);

        //Hotkey1
        JButton Hotkey1 = new JButton("F2");
        Hotkey1.setBounds(135, 17 , 100, 25); 
        Hotkey1.setBackground(Color.WHITE);
        Hotkey1.setFont(new Font("Microsoft Sans Serif", Font.PLAIN, 12));
        Hotkey1.setBorder(new LineBorder(Color.BLACK, 2));
        Hotkey1.setFocusPainted(false);
        Hotkey1.setContentAreaFilled(false);
        Hotkey1.setOpaque(true);
        frame.add(Hotkey1);

        //Hotkey2Text
        JLabel Hotkey2Text = new JLabel("Stop:", SwingConstants.RIGHT);
        Hotkey2Text.setFont(new Font("Microsoft Sans Serif", Font.PLAIN, 16));
        Hotkey2Text.setBounds(25, 13, 100, 100); 
        frame.add(Hotkey2Text);

        //MainTextText
        JLabel MainTextText = new JLabel("Text:", SwingConstants.RIGHT);
        MainTextText.setFont(new Font("Microsoft Sans Serif", Font.PLAIN, 16));
        MainTextText.setBounds(25, 53, 100, 100); 
        frame.add(MainTextText);

        // MainText Text Box
        JTextArea MainText = new JTextArea("Enter Text Here");
        MainText.setBounds(135, 95, 300, 115); 
        MainText.setBorder(BorderFactory.createEmptyBorder(0, 3, 0, 0));
        MainText.setLineWrap(true);  
        MainText.setWrapStyleWord(true);

        JScrollPane scrollPane = new JScrollPane(MainText);
        scrollPane.setBounds(135, 95, 300, 115); 
        scrollPane.setVerticalScrollBarPolicy(JScrollPane.VERTICAL_SCROLLBAR_ALWAYS); 
        UIManager.put("ScrollBar.width", 15);  
        
        scrollPane.setBorder(BorderFactory.createCompoundBorder(
            BorderFactory.createLineBorder(Color.BLACK, 2),
            BorderFactory.createEmptyBorder(0, 0, 0, 0)  
        ));
        
        scrollPane.setComponentZOrder(scrollPane.getVerticalScrollBar(), 0);
        scrollPane.setComponentZOrder(scrollPane.getViewport(), 1);
        
        scrollPane.getVerticalScrollBar().setUI(new BasicScrollBarUI() {
            @Override
            protected void configureScrollBarColors() {
                this.thumbColor = new Color(133,133,133);
                this.trackColor = new Color(240, 240, 240);
            }
            
            @Override
            protected JButton createDecreaseButton(int orientation) {
                return createZeroButton();
            }
            
            @Override
            protected JButton createIncreaseButton(int orientation) {
                return createZeroButton();
            }
            
            private JButton createZeroButton() {
                JButton button = new JButton();
                button.setPreferredSize(new Dimension(0, 0));
                button.setMinimumSize(new Dimension(0, 0));
                button.setMaximumSize(new Dimension(0, 0));
                return button;
            }
            
            @Override
            protected void paintThumb(Graphics g, JComponent c, Rectangle thumbBounds) {
                if(thumbBounds.isEmpty() || !scrollbar.isEnabled()) {
                    return;
                }
                
                Graphics2D g2 = (Graphics2D) g.create();
                g2.setRenderingHint(RenderingHints.KEY_ANTIALIASING, 
                                RenderingHints.VALUE_ANTIALIAS_ON);
                
                g2.setColor(thumbColor);
                
                int centerX = thumbBounds.x + thumbBounds.width / 2;
                int lineWidth = 5; 
                
                int arcSize = lineWidth * 1;
                g2.fillRoundRect(centerX - lineWidth/2, thumbBounds.y, 
                              lineWidth, thumbBounds.height, arcSize, arcSize);
                
                g2.dispose();
            }
            @Override
            protected void paintTrack(Graphics g, JComponent c, Rectangle trackBounds) {
                g.setColor(trackColor);
                g.fillRect(trackBounds.x, trackBounds.y, trackBounds.width, trackBounds.height);
            }
        });

        frame.add(scrollPane);
        frame.setVisible(true); 
    }
}