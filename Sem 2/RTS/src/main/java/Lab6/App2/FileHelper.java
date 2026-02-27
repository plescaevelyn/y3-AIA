package Lab6.App2;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.stream.Stream;

public class FileHelper {
    private static final Path ALLOWED_DIRECTORY = Paths.get(System.getProperty("user.dir")).toAbsolutePath().normalize();

    public static String[] readLines(String filePath, int numLines) throws IOException {
        Path path = Paths.get(filePath).toAbsolutePath().normalize();
        if (!path.startsWith(ALLOWED_DIRECTORY)) {
            throw new SecurityException("Access denied: path traversal attempt detected");
        }

        long totalLines;
        try (Stream<String> lines = Files.lines(path)) {
            totalLines = lines.count();
        }

        try (Stream<String> lines = Files.lines(path)) {
            return lines
                    .skip(Math.max(0, totalLines - numLines))
                    .toArray(String[]::new);
        }
    }
}