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

$sth = $dbh->query('SELECT username, highscore FROM korisnici ORDER BY highscore DESC LIMIT 100');
$sth->setFetchMode(PDO::FETCH_ASSOC);

$result = $sth->fetchAll();

if (count($result) > 0) {
    foreach ($result as $r) {
        echo $r['username'], "\t", $r['highscore'], "\n";
    }
}
?>