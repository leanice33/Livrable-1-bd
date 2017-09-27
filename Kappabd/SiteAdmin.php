<html>

	<head>
	<link rel="stylesheet" type="text/css" href="FormStyles.css">
	<link rel="stylesheet" href="Style.css">
		<?php
			session_start();
			if(!$_SESSION['isLogged'])
			{
			  echo "Vous devez etre connecter pour acceder a cette partie du site."; 
			  header("Location:gtfo.php"); 
			}
		?>
		
	</head>
	<body class="Background">
	
	<ul id='couleur'>
	  <li><a  href="SiteAdmin.php">Home</a></li>
	  <li><a  href="#contact">Contact</a></li>
	  <li><a  href="Index.php">Quitter</a></li>
	  <li style="float:right"><a  href="#Compte"><?php echo "Bienvenue : ".$_SESSION['nom'];?></a></li>
  	</ul>

	<h1> 
		
		<?php
			echo "Bienvenue : ".$_SESSION['nom'];
		?>
	</h1>
	
	
	
 <?php
 
 					function Modifier()
					{
					   
					}
					function Supprimer()
					{
					    $bdd = new PDO('mysql:host=localhost;dbname=Kappabd;charset=utf8', 'Kappa', 'Kappa');
					  	$stm = $bdd ->prepare("CALL Supprimer(?)");
						$id = $_GET['supprimer'];
						$value = $id;
						$stm->bindParam(1, $value); 
						
						// appel de la procÃ©dure stockÃ©e
						$stm->execute();

					}

					
					
					
					  if (isset($_GET['modifier'])) {
					    Modifier();
					  }		
					  					
					  if (isset($_GET['supprimer'])) {
					    Supprimer();
					  }	
			try
			{
				$bdd = new PDO('mysql:host=localhost;dbname=Kappabd;charset=utf8', 'Kappa', 'Kappa');
			    
			   }
			 
			   catch (PDOException $e)
			{
			       echo('Erreur de connexion: ' . $e->getMessage());
			       
			       exit();
			        
			} 
			
			
				try
				{
					$bdd = new PDO('mysql:host=localhost;dbname=Kappabd;charset=utf8', 'Kappa', 'Kappa');
				  	$stm = $bdd ->prepare("CALL ListerSpectacle()", array(PDO::ATTR_CURSOR, PDO::CURSOR_FWDONLY));

					// appel de la procÃ©dure stockÃ©e
					$stm->execute();
					
					$rows = 10; // amout of tr 
					$cols = 10;// amjount of td 
					
					echo "<table>
						  <tr>
						  <th>Date</th>
						  <th>Heure</th>
						    <th>Categorie</th>
						    <th>Salle</th>
						    <th>Artiste</th>
						    <th>Que faire</th>
						  </tr>"; 

						 while ($donnees = $stm->fetch())
					    {
					    	echo "<tr>
					    			<td>$donnees[1]</td>
									<td>$donnees[2]</td>
								    <td>$donnees[3]</td>
								    <td>$donnees[4]</td>
								    <td>$donnees[5]</td>
								    <td><ul>
										    <li><a href='index.php?modifier=true' id=$donnees[0]>modifier</a></li>
										    <li><a href='SiteAdmin.php?supprimer=$donnees[0]' id=$donnees[0]>supprimer</a></li>
										</ul>								  
								   </td>
								</tr>";
					    						    	
					    					   											   						
						}

					   	echo "</table>";				    

					

					


				$stm->closeCursor();
					
				 }
				 
				 catch (PDOException $e)
				{
				       echo('chouuuu');
				       
				       exit();
				        
				} 

				
							
				

			  
		 ?>	

	
	</body>
</html>