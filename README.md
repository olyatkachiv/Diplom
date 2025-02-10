# 🎓 Bachelor Thesis Project - Air Route Optimization Using Cellular Automata

## 📌 Overview
This project is a part of my **bachelor thesis**, which focuses on **optimizing air traffic networks in fragmented airspace** caused by **restricted, prohibited, and dangerous zones (ZON)**. The research introduces **Cellular Automata (CA)** as an innovative algorithm for route optimization and applies it to real-world airspaces, particularly in **China and Ukraine**.

The developed **software application** enables the **simulation and optimization of air traffic routes**, helping airlines and air traffic controllers **minimize congestion, enhance efficiency, and reduce operational costs**.

## 🎯 Research Goals
- **Optimize air traffic routes** to **avoid ZON** while maintaining efficiency.
- **Develop an optimization model** using **Cellular Automata (CA)**.
- **Implement a software solution** to test the proposed model on real-world flight routes.
- **Compare optimized and non-optimized routes** to evaluate performance improvements.

## 📂 Project Structure
/Diplom-master │── PathExample.sln # Visual Studio Solution file │── PathExample/ # Main project directory │ │── Form1.cs # Core logic and UI of the application │ │── Program.cs # Application entry point │ │── Properties/ # Project properties │ │── PathExample.csproj # Project configuration file │── thesis/ # Research paper & supporting materials │── БКР_ТКАЧІВ.docx # Full bachelor's thesis (Ukrainian) │── Доповідь.docx # Summary of research findings │── .gitignore # Ignored files for version control

## 🛠️ Technologies Used
- **C# (.NET Framework)**
- **Windows Forms (WinForms)**
- **Cellular Automata for Pathfinding**
- **Geographical Data Processing**
- **Adobe Photoshop (for final visualizations)**

## 🖥️ How the Model Works
1. **Airspace Data Input**
   - The user specifies the airspace structure, including:
     - **Departure and destination points (airports).**
     - **Restricted zones (ZON).**
   
2. **Grid-Based Cellular Automata Simulation**
   - The airspace is **converted into a discrete grid**.
   - **Cells** represent different airspace regions:
     - `1` - Restricted Zone (ZON)
     - `0` - Open Airspace
     - `2` - Departure Point
     - `3` - Destination Point
   - The **algorithm iterates** through the grid, computing an **optimized route**.

3. **Route Optimization Algorithm**
   - **The pathfinding algorithm selects the shortest and safest route.**
   - If a **restricted zone blocks the route**, an alternative **optimal path** is generated.
   - The system **visualizes** the optimized air route.

4. **Multiple Route Analysis**
   - The model was **tested on five flight routes in Ukraine**, including:
     - **Kyiv - Lviv**
     - **Kyiv - Kharkiv**
     - **Kyiv - Odesa**
     - **Odesa - Kharkiv**
     - **Lviv - Odesa**

5. **Comparison Between Optimized and Non-Optimized Routes**
   - **Before optimization**: Routes passed through restricted airspace, increasing flight times and risks.
   - **After optimization**: Routes successfully avoided ZON while maintaining efficiency.

## 📌 Case Study & Real-World Application
- The **initial study** was conducted using **China’s airspace**, optimizing **35 flight routes across 9 flight information regions (FIR)**.
- The **same approach was applied to Ukraine**, focusing on major airports:
  - **Boryspil International Airport (Kyiv)**
  - **Lviv International Airport**
  - **Odesa International Airport**
  - **Kharkiv International Airport**
- The **results demonstrated**:
  - **Significant reduction in flight congestion.**
  - **Minimized operational costs and enhanced route efficiency.**
  - **A safer air traffic network with reduced intersection of restricted zones.**

## 📌 Key Research Findings
- **Traditional air route networks are inefficient** in **fragmented airspace**.
- **The proposed Cellular Automata approach significantly improves route efficiency**.
- **Optimized air routes reduce travel time and minimize congestion**.
- **Air traffic safety is improved by avoiding high-risk ZON areas**.

## 🛠️ Future Enhancements
- **Real-time air traffic integration** to adapt to changing airspace conditions.
- **Machine learning models for predictive route analysis**.
- **Integration with GIS mapping tools** for enhanced visualization.

## 🤝 Contribution & License
Since this is a **bachelor thesis project**, contributions are limited. However, if you are interested in **extending the project** or conducting further research, feel free to reach out.

📌 **Author**: _Olha Tkachiv_  
🎓 **Lviv Polytechnic National University**  
