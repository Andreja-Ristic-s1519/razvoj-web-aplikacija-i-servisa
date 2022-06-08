

<?php

$hostname = 'localhost';
$username = 'root';
$password = '';
$database = 'zmija';

try {
    $dbh = new PDO('mysql:host=' . $hostname . ';dbname=' . $database, $username, $password);
} catch (PDOException $e) {
    echo 'An error has occurred.', $e->getMessage();
}

$stmt = $pdo->prepare("SELECT highscore FROM korisnici WHERE username = ?");
$stmt->execute($_POST['username']);
$user = $stmt->fetch();



if (count($user) > 0) {
    foreach ($user as $r) {
        echo  $r['highscore'], "\n";
    }
}

