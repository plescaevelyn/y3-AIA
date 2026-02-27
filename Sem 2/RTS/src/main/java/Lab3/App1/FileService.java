package Lab3.App1;

import java.io.*;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Date;

public class FileService implements AutoCloseable {
    private static final Path ALLOWED_DIRECTORY = Paths.get(System.getProperty("user.dir")).toAbsolutePath().normalize();

    private final String fileName;
    private BufferedReader in;
    private PrintWriter out;

    public FileService(String fname) throws IOException {
        Path path = Paths.get(fname).toAbsolutePath().normalize();
        if (!path.startsWith(ALLOWED_DIRECTORY)) {
            throw new SecurityException("Access denied: path traversal attempt detected");
        }

        this.fileName = path.toString();
        out = new PrintWriter(new FileWriter(fileName, true));
        in = new BufferedReader(new FileReader(fileName));
    }

    public void write(String msg) {
        Date date = new Date(System.currentTimeMillis());
        synchronized (this) {
            out.println("Date: " + date);
            out.println("Message: " + msg);
            out.flush();
        }
    }

    public String read() throws IOException {
        String iterator, last = "no message to read";
        synchronized (this) {
            while ((iterator = in.readLine()) != null) {
                last = new Date(System.currentTimeMillis()) + " - " + iterator;
            }
        }
        return last;
    }

    @Override
    public void close() {
        if (out != null) {
            out.close();
        }
        if (in != null) {
            try {
                in.close();
            } catch (IOException e) {
                // Ignore close exception
            }
        }
    }
}
