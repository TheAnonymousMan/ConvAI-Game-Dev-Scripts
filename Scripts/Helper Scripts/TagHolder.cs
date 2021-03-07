public class Axis
{
    public const string HORIZONTAL = "Horizontal";
    public const string VERTICAL = "Vertical";
}

public class MouseAxis
{
    public const string MOUSE_Y = "Mouse Y";
    public const string MOUSE_X = "Mouse X";
}

public class AnimationTags
{
    public const string ZOOM_IN_AIM = "ZoomIn";
    public const string ZOOM_OUT_AIM = "ZoomOut";

    public const string SHOOT_TRIGGER = "Shoot";
    public const string AIM_PARAMETER = "Aim";

    public const string WALK_PARAMETER = "Walk";
    public const string RUN_PARAMETER = "Run";
    public const string ATTACK_TRIGGER = "Attack";
    public const string DEAD_TRIGGER = "Dead";
}

public class Tags
{
    public const string LOOK_ROOT = "Look Root";
    public const string ZOOM_CAMERA = "FP Camera";
    public const string CROSSHAIR = "Crosshair";
    public const string ARROW_TAG = "Arrow";

    public const string AXE_TAG = "Axe";

    public const string PLAYER_TAG = "Player";
    public const string ENEMY_TAG = "Enemy";
}

public class Speech
{
    public const string AUDIO_FILENAME = "soundfile.wav";
    public const string OUTPUT_FILENAME = "output.wav";
    public const string GCP_CREDENTIALS
            = "{"
            + "\"type\": \"service_account\","
            + "\"project_id\": \"convai-fps-speech-recognition\","
            + "\"private_key_id\": \"73ce7cec3f38b02c26a9faf15747c5d0840e8a72\","
            + "\"private_key\": \"-----BEGIN PRIVATE KEY-----\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQC7uuPLUl4AOe2Z\nDgd7YF4t8PSOC+NRR8VdzA0rYkTZkKX2duSoP94huuGiTt5PweKIzD514P6IB73j\n1kRK9Jp/Aw6xcMFqtAC+qBSgVedspgDFzOJ5e5Uom6uFG/oV7m/rGNtCa6WGhZk+\nlUgnaaODdzP3fpIG8syvSW4N1vhpSQ5FQsZ5WS01TPbcDVromne1JCSkgr/a2/JC\niqCUmOgdXdDbOximZF9YL0UfUk8M9FB9hpepvkaM56h/mK6ekT18vDeWsc4nlR4k\n/BZP76T/EYxVMgQnZxKEE8anlpOvJXCtdS5IeinyqjUm2RZjmXb9GAj1WoLelYDo\nlkdN1s/pAgMBAAECggEAPra04Zf/EhlH//D5W+R6IePUdt2Oz3jn/KktnxghgwL5\nBmh6g6Bubxs0xFmPl9pf+K4ukYeb0Eqxy3qpbtbfA948GtfdrW07sHWLCnMYMCoW\nqP2EjOvVjO7QMlQBzDDOz52Kpdo7PkDETG1nYM9AEiuQvzXXx5119nrT2qi9bMIp\nhx6bKzc+Wmz75PXGExqrGNTuqrzbg0tJrJUlM83VcZho84WTSrqol08leaBamACj\n7K3XGswrFDGvnY0MO5dPxeIgRwUhNL0IV8b8zXWX9nuKmU4lNiT3qFkRxFq+1MKt\n4zifC7Fqf9dKyJHBzf3SXjzs8KXtE0G4ksz2aAKrdwKBgQDvlp4NvWoXmfB2rOgW\nwlUWAz3z5p0I6xByHe/Rheux/cLiW5JwyDMfd/vVPhvSasLIiv9x5lTYRzXvHdIb\nG0n7FqyBpGoGdUjhJgxFs6xGEb2kjR3SCqiSrymtP6f1MSYsl1RH1vyRU8ZW5bXZ\ngvwW4mcA8kp/SO8vwhIa1f3S0wKBgQDIluS5veY85K2a8bVwqoKCllUpm2oa9OI5\n6SLq4CBg36/y/tNL27bMCK9fkhmnv0nn6GeRPNWTGdGx6Eipu9G2KCL3mElbIPmM\n7OQCiL4zVDVSTOn743tI3X6TQOIffSq0H6/6YcsST+4QIGcX9DXvaZ8ZGbIj5twW\nzuIH3pZE0wKBgQDcrVJvPWQW0QeXh7NOIzjTybCqkmNZ74l6UvCtgDiT/TQf4lCD\n6SKNfapLw6VErmky5jRa6NiFTTH0SPdZWE1QJJZH4vR1dlnmZ3EuUkv/Th/rDL/G\n02JpmUU9+j/tq5OJxukuMmr4QL2TFInnCqq/OVG+oWzUyIzm5E5gwXHFWQKBgDfe\nv4p0uEJRt4EmvdDJzVwuHz5diWpEtxZGN3GQR7Rz2YAnNhc09W9TI/XMrdSpVR6A\n/wfXF+3HDT8uYb7VD45bE5I/Gn+Faby05rVF/SQy2j84KRv9uoMLHoxJUDJRHKnb\nAZsNzhAlrztSqyRi4vryQlwtag7R6I95xD9I4jX9AoGAdacyz9Tx+A6xQaI1fzzx\nKYKJJsIl9jRQtSe0+j673LO6ZhfX8+2n87YN/gRGafphywZvhLhpgfvAW4JEJPpj\n3GOy7GY8kN6jUlDzs8F85FNsDKJZ2rk4PEE7ssjP1aFA9+OvDgrRnbtg3Ct88yyS\nwKBiuqI7Y+yrqPwRalG3nqM=\n-----END PRIVATE KEY-----\n\","
            + "\"client_email\": \"my-speech-to-text-sa@convai-fps-speech-recognition.iam.gserviceaccount.com\","
            + "\"client_id\": \"113406910716420003994\","
            + "\"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\","
            + "\"token_uri\": \"https://oauth2.googleapis.com/token\","
            + "\"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\","
            + "\"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/my-speech-to-text-sa%40convai-fps-speech-recognition.iam.gserviceaccount.com\""
            + "}";
    public const string CONVAI_GCP_CREDENTIALS
            = "{"
            + "\"type\": \"service_account\","
            + "\"project_id\": \"convai-services\","
            + "\"private_key_id\": \"1e7142dbfa66f09a9266ef00aecf400112b090c1\","
            + "\"private_key\": \"-----BEGIN PRIVATE KEY-----\nMIIEvAIBADANBgkqhkiG9w0BAQEFAASCBKYwggSiAgEAAoIBAQCG8+K+XIfZfzXw\nBQpQtIdNNUGlqOJ3mvYMLQSrdxnyUEH7FzEQX5zJ6mURoa2pZ4lsn83638WxajIj\nnuBEOhMORb+ejpEeCjI0hkCM5B1SPMPH2bjfWAQXlvPTeU3Swn0bv4Qfi5AXgt/x\nTx3wmHR9Fc1+hFUkX1SeU+UQLZ5Sq62k++m8PlO6M3TyBwYDkTN3RnnI1VPJTEXl\n9S3uGwDlgENkwCSZXhYLzsa/xE9yb8uwMOWKsbqxoak7UWiUJsCaMfKIOHubqeh3\nRLHdcG63r8BZtMYwZ3u9lRKR0YmL8e4On2Ujy4vW0sY3NF3w+oWqW/eFkIEk+zX/\n05liB2RzAgMBAAECggEAHeArD8JzTqqTWcX74R7+HxENretj61+SXeKveHge9d5f\npQMe2QWZs7eg1VTqGakyqqn8EzBr1xlv7SPUeTY0FsJJKAReyvwt3iPkcWxks1qB\nayJfg448Ja7E3smpeWGWCckNqmAer53JDuZZdfSCQVjMy9fm82zpUj23Zav7s0g9\nFOvZSy+YcCM0z/hwQxUwolmHTmCjjczpIqhFt7HmwJNJtFh0YSHFOey+Jy/QAgKc\nS7VMZJRKnWjb9b2NPxiTYbiuoo6lhkTyOIoppX/YHF6gz61zfrA7pDqMHIM5wO23\nZzsXNMZcDXWAuZ+Z7rn2x9tu19bfYo7k5H1mj0ttEQKBgQC8DiIxP6yNs5nQsfWg\n6zDwIj0y4YUV9q3OIBisewjVjQP57yoeit+Mk/d60EqpUq3KpgL5CoiPLnj4aMRj\nPkK6fPexdJlp9oBo4B+hC8pSvad4FiBBbRZyKuTmqkFc2o6cCrIn69xcL7aPOIl4\nKXfhprqzS932BsB4Y0JPPP4HwwKBgQC3th5LIdU1uyg6+CJmgaVbOPpkC7BxO2UG\nuKWh6GFpxgGY9u27bSEyxpBfMi6cYN+9MJTqN8CD20BPhK8cYsiNII1vOPPuJ3F2\nh7CiDPiPxqM35Jxt5I4uAp+mYpO1KgRydM9C/aA1/9GQrCMO0L/MKwtzFdJaZKLf\nW//7zFYVkQKBgGf8bL3M1s6YRHKZJRixVKNEW5DaEWxetibnqp0df3oOeudmb2Tq\nJ8klPNClgtN0S3NmLvik8XQzH2NFE2tJTz6twY1Xy0lDrCfR3st/qIXuJz+JBJcJ\nCkNhIqfF91Sv6fGxHGhkzLoRDCLQAXv3ejnFpzFjvz2+6Ajp4g3MzS9fAoGATJXe\nkSG8mZa5UcQJy0P25E2fjL+Wwc2p8yBc5F9U5NyH4/Xk64K2GU3P9++aoNR90YgE\nPJQbbJyldcDxo1rHEpZkf951Sm4lDe3JQ/U2VfHQL0fdsq5aW3H6jkmAHEE082Yg\n1WOYO4q3GaG5R77chkfXkRWiyM41W/olgBoSNRECgYBpytPkb98O8dnza9aixaqL\nS/MFjGM0MwBpC0/MBreQJ6/NUMqHpRwn++rt9c/AB/zBR1rxr9DWeKZ1KF6g7s5Z\nlU5CHToebVsrf6nMb2u50MEgwA9EEg4YmdmXQcO46uVDyERIjhDVa7teeRxGUpcU\noueVNKD/DRz6xnmp/W361Q==\n-----END PRIVATE KEY-----\n\","
            + "\"client_email\": \"speech@convai-services.iam.gserviceaccount.com\","
            + "\"client_id\": \"100690963737591693706\","
            + "\"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\","
            + "\"token_uri\": \"https://oauth2.googleapis.com/token\","
            + "\"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\","
            + "\"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/speech%40convai-services.iam.gserviceaccount.com\""
            + "}";
}

public class API
{
    public const string INTENT_CLASSIFIER_URL = "http://api.convai.com/zeroshot";
    public const string QUESTION_ANSWERER_URL = "http://api.convai.com/qa_api";
    public const string CHIT_CHAT_URL = "http://35.225.3.44:9000/webhook";
}
