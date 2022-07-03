using System.Threading;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;
using System.ComponentModel.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class sinavManager : MonoBehaviour
{
    //transform the car variables
    [SerializeField] public GameObject carObject;
    [SerializeField] public CarController carController;
    [SerializeField] public carCheckpointTrigger carTrigger;
    [SerializeField] private Vector3 posIn = new Vector3(0, 0, 0);
    [SerializeField] private Quaternion rotIn = new Quaternion(0, 0, 0, 0);

    //sinav objects
    public checkpointTrigger[] checkpoints;
    public checkpointTrigger anifren;
    public checkpointTrigger gerigitmealani;
    public checkpointTrigger gerigitmekontrol;
    [SerializeField] private parkAlaniTrigger arkaLParkalaniTrigger; 
    [SerializeField] private parkAlaniTrigger paralelParkalaniTrigger; 
    public trafikLambasi[] trafikLambalari;
    public GameObject sinavAniFren;
    public GameObject arkaLPark;
    public GameObject paralelPark;
    public GameObject geriGitme;

    //other objects
    public GameObject basarili;
    public GameObject basarisiz;
    public GameObject textBox;

    //text variables
    [SerializeField] private Text theText;

    //controls
    public bool anifrenDone = false;
    public bool arkaLDone = false;
    public bool paralelDone = false;
    public bool geriGitmeDone = false;
    public int checkpointCounter = 0;
    public int kirmizicounter=0;
    public int saricounter=0;

    void Start()
    {
        posIn = new Vector3(45,1,-42);
        rotIn = new Quaternion(0,0,0,30);
        carObject.transform.SetPositionAndRotation(posIn, rotIn);
        carObject.transform.Rotate(0, 234, 0);
    }

    void Update()
    {
        trafikLambasiKontrol();
        if(carTrigger.checkedpoint==checkpointCounter+1){
            if(checkpoints[checkpointCounter].checkedCar){
                checkpointCounter++;
            }
            else{//rota dışı davranış - fail
                basarisiz.SetActive(true);
            }
        }
        //anifren
        if(checkpoints[14].checkedCar){
            textBox.SetActive(true);
            theText.text="Ani Fren Bölgesi";
        }
        if(checkpointCounter==14){
            aniFrenControl();
        }
        if(checkpoints[15].checkedCar){
            textBox.SetActive(false);
            if(!anifrenDone){
                basarisiz.SetActive(true);
            }
        }
        //arkaL
        if(checkpoints[21].checkedCar){
            textBox.SetActive(true);
            theText.text="Arka L Park Bölgesi";
        }
        if(checkpointCounter==22){
            arkaLParkKontrol();
        }
        if(checkpoints[23].checkedCar){
            textBox.SetActive(false);
            if(!arkaLDone){
                basarisiz.SetActive(true);
            }
        }
        //paralel
        if(checkpoints[23].checkedCar){
            textBox.SetActive(true);
            theText.text="Paralel Park Bölgesi";
        }
        if(checkpointCounter==24){
            paralelParkKontrol();
        }
        if(checkpoints[25].checkedCar){
            textBox.SetActive(false);
            if(!paralelDone){
                basarisiz.SetActive(true);
            }
        }
        //gerigitme
        if(checkpoints[37].checkedCar){
            textBox.SetActive(true);
            theText.text="Geri 50m Gitme Bölgesi";
        }
        if(checkpointCounter==37||checkpointCounter==36||checkpointCounter==38){
            geriGitmeKontrol();
        }
        if(checkpoints[39].checkedCar){
            textBox.SetActive(false);
            if(!geriGitmeDone){
                basarisiz.SetActive(true);
            }
            else{//sınav başarılı - END
                basarili.SetActive(true);
            }
        }
    }

    void aniFrenControl(){
        if(carController.isBreaking || carController.speed<5){//ani fren passed
            anifrenDone=true;
        }
        if(anifren.checkedCar && !anifren.alanicinde && !anifrenDone){//ani fren fail
            anifrenDone=false;
            basarisiz.SetActive(true);
        }
    }

    void arkaLParkKontrol(){
        if(arkaLParkalaniTrigger.frontParkEdiliMi && arkaLParkalaniTrigger.rearParkEdildiMi && arkaLParkalaniTrigger.ilkRear){
            arkaLDone=true;
        }
        if(arkaLParkalaniTrigger.ilkFront && !arkaLDone){//arka l fail
            arkaLDone=false;
            basarisiz.SetActive(true);
        }
    }

    void paralelParkKontrol(){
        if(paralelParkalaniTrigger.frontParkEdiliMi && paralelParkalaniTrigger.rearParkEdildiMi && paralelParkalaniTrigger.ilkRear){
            paralelDone=true;
        }
        if(paralelParkalaniTrigger.ilkFront && !paralelDone){//paralel fail
            paralelDone=false;
            basarisiz.SetActive(true);
        }
    }

    void geriGitmeKontrol(){
        if(carController.currentvites==otoviteslevels.REVERSE || gerigitmekontrol.checkedCar){//geri gitme passed (works wrongly - deneme testleri uygulanıyor)
            geriGitmeDone=true;
        }
        if(gerigitmealani.checkedCar && !gerigitmealani.alanicinde && !gerigitmekontrol.checkedCar && !geriGitmeDone){//geri gitme fail
            geriGitmeDone=false;
            basarisiz.SetActive(true);
        }
    }

    void trafikLambasiKontrol(){
     /*   if(checkpointCounter==3){
            if(trafikLambalari[0].kirmiziyaniyor && checkpoints[3].checkedCar && !checkpoints[3].alanicinde){
                kirmizicounter++;
            }
            if(trafikLambalari[0].sariyaniyor && checkpoints[3].checkedCar && !checkpoints[3].alanicinde){
                saricounter++;
            }
        }
        else if(checkpointCounter==10){
            if(trafikLambalari[1].kirmiziyaniyor && checkpoints[10].checkedCar && !checkpoints[10].alanicinde){
                kirmizicounter++;
            }
            if(trafikLambalari[1].sariyaniyor && checkpoints[10].checkedCar && !checkpoints[10].alanicinde){
                saricounter++;
            }
        }
        else if(checkpointCounter==12){
            if(trafikLambalari[2].kirmiziyaniyor && checkpoints[12].checkedCar && !checkpoints[12].alanicinde){
                kirmizicounter++;
            }
            if(trafikLambalari[2].sariyaniyor && checkpoints[12].checkedCar && !checkpoints[12].alanicinde){
                saricounter++;
            }
        }
        else if(checkpointCounter==15){
            if(trafikLambalari[3].kirmiziyaniyor && checkpoints[15].checkedCar && !checkpoints[15].alanicinde){
                kirmizicounter++;
            }
            if(trafikLambalari[3].sariyaniyor && checkpoints[15].checkedCar && !checkpoints[15].alanicinde){
                saricounter++;
            }
        }
        else if(checkpointCounter==16){
            if(trafikLambalari[4].kirmiziyaniyor && checkpoints[16].checkedCar && !checkpoints[16].alanicinde){
                kirmizicounter++;
            }
            if(trafikLambalari[4].sariyaniyor && checkpoints[16].checkedCar && !checkpoints[16].alanicinde){
                saricounter++;
            }
        }
        else if(checkpointCounter==18){
            if(trafikLambalari[5].kirmiziyaniyor && checkpoints[18].checkedCar && !checkpoints[18].alanicinde){
                kirmizicounter++;
            }
            if(trafikLambalari[5].sariyaniyor && checkpoints[18].checkedCar && !checkpoints[18].alanicinde){
                saricounter++;
            }
        }
        else if(checkpointCounter==25){
            if(trafikLambalari[6].kirmiziyaniyor && checkpoints[25].checkedCar && !checkpoints[25].alanicinde){
                kirmizicounter++;
            }
            if(trafikLambalari[6].sariyaniyor && checkpoints[25].checkedCar && !checkpoints[25].alanicinde){
                saricounter++;
            }
        }
        else if(checkpointCounter==28){
            if(trafikLambalari[7].kirmiziyaniyor && checkpoints[28].checkedCar && !checkpoints[28].alanicinde){
                kirmizicounter++;
            }
            if(trafikLambalari[7].sariyaniyor && checkpoints[28].checkedCar && !checkpoints[28].alanicinde){
                saricounter++;
            }
        }
        else if(checkpointCounter==31){
            if(trafikLambalari[8].kirmiziyaniyor && checkpoints[31].checkedCar && !checkpoints[31].alanicinde){
                kirmizicounter++;
            }
            if(trafikLambalari[8].sariyaniyor && checkpoints[31].checkedCar && !checkpoints[31].alanicinde){
                saricounter++;
            }
        }
        else if(checkpointCounter==36){
            if(trafikLambalari[9].kirmiziyaniyor && checkpoints[36].checkedCar && !checkpoints[36].alanicinde){
                kirmizicounter++;
            }
            if(trafikLambalari[9].sariyaniyor && checkpoints[36].checkedCar && !checkpoints[36].alanicinde){
                saricounter++;
            }
        }*/
    }

    public void basarisizutton()
    {
        SahneGecisKontrol.activategoVites = true;
        SceneManager.LoadScene("Arayüz");
    }
}
