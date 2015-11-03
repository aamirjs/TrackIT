using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;


public class Incidents: List<Incident>
{
    public Incidents()
    {
    }
}


public class Incident
{

    //iIncidentID	vcIncidentType	    vcIncidentLocation	
    //vcIncident	    vcImpact	        vcDescription	
    //dtincidentDate	iIncidentStatusID	dtUpdateTime 

    public Incident()
    {
    }

    private int iIncidentID;

    public int IIncidentID
    {
        get { return iIncidentID; }
        set { iIncidentID = value; }
    }
    private String vcIncidentNumber;

    public String VCIncidentNumber
    {
        get { return vcIncidentNumber; }
        set { vcIncidentNumber = value; }
    }

    private String vcIncidentType;

    public String VCIncidentType
    {
        get { return vcIncidentType; }
        set { vcIncidentType = value; }
    }

    private String vcIncidentLocation;

    public String VCIncidentLocation
    {
        get { return vcIncidentLocation; }
        set { vcIncidentLocation = value; }
    }


    private String vcIncident;

    public String VCIncident
    {
        get { return vcIncident; }
        set { vcIncident = value; }
    }



    private String vcImpact;

    public String VCImpact
    {
        get { return vcImpact; }
        set { vcImpact = value; }
    }

    private String vcDescription;

    public String VCDescription
    {
        get { return vcDescription; }
        set { vcDescription = value; }
    }

    private DateTime dtincidentDate;

    public DateTime DTincidentDate
    {
        get { return dtincidentDate; }
        set { dtincidentDate = value; }
    }

    private DateTime dtIncidentTime;

    public DateTime DTIncidentTime
    {
        get { return dtIncidentTime; }
        set { dtIncidentTime = value; }
    }   

    
    private int iIncidentStatusID;

    public int IIncidentStatusID
    {
        get { return iIncidentStatusID; }
        set { iIncidentStatusID = value; }
    }
    private DateTime dtUpdateTime;

    public DateTime DtUpdateTime
    {
        get { return dtUpdateTime; }
        set { dtUpdateTime = value; }
    }

}
