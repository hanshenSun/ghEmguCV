using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Emgu.CV;
using Emgu.CV.CvEnum;           // usual Emgu Cv imports
using Emgu.CV.Structure;        //
using Emgu.CV.UI;

namespace ghEmguCV
{
    public class ghEmguCVComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public ghEmguCVComponent()
          : base("CannyStill", "Canny",
              "Image Tracing",
              "CV", "CV")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("folder", "Folder Directory", "Directory to the folder that contains images", GH_ParamAccess.item);
            pManager.AddTextParameter("imgName", "Image Name", "Name of the Image to process", GH_ParamAccess.item);
            pManager[1].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("output", "output", "output", GH_ParamAccess.list);

        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string fileDirectory = "";
            DA.GetData(0, ref fileDirectory);

            Mat newImg = new Mat(fileDirectory, Emgu.CV.CvEnum.ImreadModes.Grayscale);
            Mat imgBlurred = new Mat(newImg.Size, DepthType.Cv8U, 1);
            Mat imgCanny = new Mat(newImg.Size, DepthType.Cv8U, 1);

            CvInvoke.Canny(imgBlurred, imgCanny, 100, 200);
            System.Array outputData = imgCanny.Data;


            List<string> dataContainer = new List<string>();
            foreach(var data in outputData)
            {
                dataContainer.Add(data.ToString();
            }

            DA.SetDataList(0, dataContainer);

        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("3f38944a-a787-4f44-a36e-19c5e6f0f868"); }
        }
    }
}
